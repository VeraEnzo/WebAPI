using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class PedidoDetalleForm : Form
    {
        private int _pedidoId;
        private decimal _totalPedido;

        public PedidoDetalleForm(int pedidoId, decimal totalPedido)
        {
            InitializeComponent();
            _pedidoId = pedidoId;
            _totalPedido = totalPedido;
        }

        private async void PedidoDetalleForm_Load(object sender, EventArgs e)
        {
            tituloLabel.Text = $"Detalle del Pedido #{_pedidoId}";
            totalLabel.Text = _totalPedido.ToString("C");

            await CargarDetalles();
        }

        private async Task CargarDetalles()
        {
            try
            {
                var detalles = await PedidoApiClient.GetPedidoDetalleAsync(_pedidoId);
                detalleDataGridView.DataSource = detalles;
                ConfigurarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el detalle del pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrilla()
        {
            if (detalleDataGridView.Columns["ProductoId"] != null)
                detalleDataGridView.Columns["ProductoId"].Visible = false;
        }
    }
}