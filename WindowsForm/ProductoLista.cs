using API.Clients;
using DTOs;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class ProductoLista : Form
    {
        private bool esInvitado;
        private bool esAdmin;
        public ProductoLista(bool invitado = false, bool admin = false)
        {
            InitializeComponent();
            esInvitado = invitado;
            esAdmin = admin;
        }

        private void ProductoLista_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();

            if (esInvitado)
            {
                agregarButton.Visible = false;
                modificarButton.Visible = false;
                eliminarButton.Visible = false;
            }
            else if (esAdmin)
            {
                usuariosButton.Visible = true;
            }
            else
            {
                usuariosButton.Visible = false;
            }
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            ProductoDetalle productoDetalle = new ProductoDetalle();

            ProductoDTO productoNuevo = new ProductoDTO();

            productoDetalle.Mode = FormMode.Add;
            productoDetalle.Producto = productoNuevo;

            productoDetalle.ShowDialog();

            this.GetAllAndLoad();
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoDetalle productoDetalle = new ProductoDetalle();

                int id = this.SelectedItem().Id;

                ProductoDTO producto = await ProductoApiClient.GetAsync(id);

                productoDetalle.Mode = FormMode.Update;
                productoDetalle.Producto = producto;

                productoDetalle.ShowDialog();

                this.GetAllAndLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar producto para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = this.SelectedItem().Id;

                var result = MessageBox.Show($"¿Está seguro que desea eliminar el producto con Id {id}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await ProductoApiClient.DeleteAsync(id);
                    this.GetAllAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void GetAllAndLoad()
        {
            try
            {
                this.productosDataGridView.DataSource = null;
                this.productosDataGridView.DataSource = await ProductoApiClient.GetAllAsync();

                if (this.productosDataGridView.Rows.Count > 0)
                {
                    this.productosDataGridView.Rows[0].Selected = true;
                    // Si después agregás botones de modificar/eliminar:
                    // this.eliminarButton.Enabled = true;
                    // this.modificarButton.Enabled = true;
                }
                else
                {
                    // this.eliminarButton.Enabled = false;
                    // this.modificarButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ProductoDTO SelectedItem()
        {
            ProductoDTO cliente;

            cliente = (ProductoDTO)productosDataGridView.SelectedRows[0].DataBoundItem;

            return cliente;
        }

        private void usuariosButton_Click(object sender, EventArgs e)
        {
            var usuarioListaForm = new UsuarioLista();
            usuarioListaForm.ShowDialog();
        }
    }
}
