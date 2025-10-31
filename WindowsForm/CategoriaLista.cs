using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class CategoriaLista : Form
    {
        public CategoriaLista()
        {
            InitializeComponent();
        }

        private async void CategoriaLista_Load(object sender, EventArgs e)
        {
            await CargarCategorias();
        }

        private async Task CargarCategorias()
        {
            try
            {
                categoriasDataGridView.DataSource = null;
                // GetAll() solo trae las activas, lo cual es correcto para esta vista
                var listaCategorias = await CategoriaApiClient.GetAllAsync();
                categoriasDataGridView.DataSource = listaCategorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private CategoriaDTO? ObtenerCategoriaSeleccionada()
        {
            if (categoriasDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una categoría de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return (CategoriaDTO)categoriasDataGridView.SelectedRows[0].DataBoundItem;
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            var formDetalle = new CategoriaDetalle(FormMode.Add);
            formDetalle.ShowDialog();
            await CargarCategorias();
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            var categoriaSeleccionada = ObtenerCategoriaSeleccionada();
            if (categoriaSeleccionada == null) return;

            var formDetalle = new CategoriaDetalle(FormMode.Update, categoriaSeleccionada);
            formDetalle.ShowDialog();
            await CargarCategorias();
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            var categoriaSeleccionada = ObtenerCategoriaSeleccionada();
            if (categoriaSeleccionada == null) return;

            var confirmacion = MessageBox.Show($"¿Está seguro que desea desactivar la categoría '{categoriaSeleccionada.Nombre}'?", "Confirmar Desactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    await CategoriaApiClient.DeleteAsync(categoriaSeleccionada.Id);
                    MessageBox.Show("Categoría desactivada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarCategorias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al desactivar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}