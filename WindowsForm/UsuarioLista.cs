using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class UsuarioLista : Form
    {
        public UsuarioLista()
        {
            InitializeComponent();
        }

        private async void UsuarioLista_Load(object sender, EventArgs e)
        {
            // Cuando el formulario carga, llama al método para cargar usuarios
            await CargarUsuarios();
        }

        private async Task CargarUsuarios()
        {
            try
            {
                // Limpia los datos anteriores
                usuariosDataGridView.DataSource = null;

                // Llama al ApiClient (que ya envía el token)
                var listaUsuarios = await UsuarioApiClient.GetAllAsync();

                // Carga los nuevos datos en la grilla
                usuariosDataGridView.DataSource = listaUsuarios;
                ConfigurarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrilla()
        {
            // Ocultar columnas que no queremos ver
            if (usuariosDataGridView.Columns["Contrasena"] != null)
                usuariosDataGridView.Columns["Contrasena"].Visible = false;

            if (usuariosDataGridView.Columns["Id"] != null)
                usuariosDataGridView.Columns["Id"].Width = 50;
        }

        private UsuarioDTO? ObtenerUsuarioSeleccionado()
        {
            if (usuariosDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return (UsuarioDTO)usuariosDataGridView.SelectedRows[0].DataBoundItem;
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            // Abre el formulario de detalle en modo "Agregar"
            var formDetalle = new UsuarioDetalle(FormMode.Add);
            formDetalle.ShowDialog();

            // Al cerrar el formulario, recargamos la lista
            await CargarUsuarios();
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            var usuarioSeleccionado = ObtenerUsuarioSeleccionado();
            if (usuarioSeleccionado == null) return;

            // Abre el formulario de detalle en modo "Modificar"
            var formDetalle = new UsuarioDetalle(FormMode.Update, usuarioSeleccionado);
            formDetalle.ShowDialog();

            await CargarUsuarios();
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            var usuarioSeleccionado = ObtenerUsuarioSeleccionado();
            if (usuarioSeleccionado == null) return;

            var confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar al usuario '{usuarioSeleccionado.Nombre} {usuarioSeleccionado.Apellido}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // Llama a la API para eliminar
                    await UsuarioApiClient.DeleteAsync(usuarioSeleccionado.Id);
                    MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}