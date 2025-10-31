using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class PedidosLista : Form
    {
        private bool _esAdmin;
        private List<PedidoResumenDTO>? _todosLosPedidos; // Lista completa para el admin

        public PedidosLista()
        {
            InitializeComponent();
            _esAdmin = GestorDeSesion.EsAdmin;
        }

        private async void PedidosLista_Load(object sender, EventArgs e)
        {
            filtroPanel.Visible = _esAdmin;
            if (!_esAdmin)
            {
                // Ajustar la grilla si no es admin
                pedidosDataGridView.Location = new System.Drawing.Point(12, 12);
                pedidosDataGridView.Size = new System.Drawing.Size(776, 380);
            }

            await CargarPedidos();
        }

        private async Task CargarPedidos()
        {
            try
            {
                pedidosDataGridView.DataSource = null;
                List<PedidoResumenDTO> pedidos;

                if (_esAdmin)
                {
                    _todosLosPedidos = await PedidoApiClient.GetAllPedidosAsync();
                    pedidos = _todosLosPedidos;
                }
                else
                {
                    pedidos = await PedidoApiClient.GetMisPedidosAsync();
                }

                pedidosDataGridView.DataSource = pedidos;
                AplicarFiltros(); // Aplicar filtros (si es admin)
                ConfigurarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrilla()
        {
            // Ocultar la columna de UsuarioId si no es admin
            if (pedidosDataGridView.Columns["UsuarioId"] != null)
                pedidosDataGridView.Columns["UsuarioId"].Visible = _esAdmin;

            if (pedidosDataGridView.Columns["NombreUsuario"] != null)
                pedidosDataGridView.Columns["NombreUsuario"].Visible = _esAdmin;
        }

        private void filtros_TextChanged(object sender, EventArgs e)
        {
            // Este evento se dispara cada vez que se escribe en los filtros
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            if (!_esAdmin || _todosLosPedidos == null) return; // Solo el admin filtra

            IEnumerable<PedidoResumenDTO> resultado = _todosLosPedidos;

            // Filtrar por ID
            if (!string.IsNullOrWhiteSpace(idFiltroTextBox.Text) && int.TryParse(idFiltroTextBox.Text, out int id))
            {
                resultado = resultado.Where(p => p.Id == id);
            }

            // Filtrar por Nombre
            if (!string.IsNullOrWhiteSpace(nombreFiltroTextBox.Text))
            {
                resultado = resultado.Where(p => p.NombreUsuario.Contains(nombreFiltroTextBox.Text, StringComparison.OrdinalIgnoreCase));
            }

            pedidosDataGridView.DataSource = resultado.ToList();
        }

        private void verDetalleButton_Click(object sender, EventArgs e)
        {
            if (pedidosDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un pedido de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var pedidoSeleccionado = (PedidoResumenDTO)pedidosDataGridView.SelectedRows[0].DataBoundItem;

            // Abrimos el formulario de detalle
            var formDetalle = new PedidoDetalleForm(pedidoSeleccionado.Id, pedidoSeleccionado.Total);
            formDetalle.MdiParent = this.MdiParent;
            formDetalle.Show();
        }
    }
}