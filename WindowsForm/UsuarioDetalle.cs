using API.Clients;
using DTOs;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsForms
{
    // Usamos el mismo FormMode de ProductoDetalle
    // Si no es público, copia la definición aquí:
    // public enum FormMode { Add, Update }

    public partial class UsuarioDetalle : Form
    {
        private FormMode _mode;
        private UsuarioDTO _usuario;

        public UsuarioDetalle(FormMode mode, UsuarioDTO? usuario = null)
        {
            InitializeComponent();
            _mode = mode;

            // Si el usuario es nulo (modo Add), creamos uno nuevo.
            _usuario = usuario ?? new UsuarioDTO();
        }

        private void UsuarioDetalle_Load(object sender, EventArgs e)
        {
            if (_mode == FormMode.Update)
            {
                this.Text = "Modificar Usuario";

                // Llenar el formulario con los datos del usuario
                idTextBox.Text = _usuario.Id.ToString();
                nombreTextBox.Text = _usuario.Nombre;
                apellidoTextBox.Text = _usuario.Apellido;
                emailTextBox.Text = _usuario.Email;
                adminCheckBox.Checked = _usuario.EsAdmin;

                // En modo Update, la contraseña se deja en blanco para no cambiarla
                contrasenaLabel.Text = "Contraseña (dejar en blanco para no cambiar)";
            }
            else
            {
                this.Text = "Agregar Usuario";
                idTextBox.Text = "(Nuevo)";
            }
        }

        private async void guardarButton_Click(object sender, EventArgs e)
        {
            // 1. Validar datos
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text) ||
                string.IsNullOrWhiteSpace(apellidoTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("Nombre, Apellido y Email son obligatorios.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_mode == FormMode.Add && string.IsNullOrWhiteSpace(contrasenaTextBox.Text))
            {
                MessageBox.Show("La contraseña es obligatoria para un usuario nuevo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Llenar el objeto DTO
            _usuario.Nombre = nombreTextBox.Text;
            _usuario.Apellido = apellidoTextBox.Text;
            _usuario.Email = emailTextBox.Text;
            _usuario.EsAdmin = adminCheckBox.Checked;

            // Solo enviar la contraseña si se escribió algo
            if (!string.IsNullOrWhiteSpace(contrasenaTextBox.Text))
            {
                _usuario.Contrasena = contrasenaTextBox.Text;
            }

            try
            {
                // 3. Llamar a la API
                if (_mode == FormMode.Add)
                {
                    await UsuarioApiClient.AddAsync(_usuario);
                    MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await UsuarioApiClient.UpdateAsync(_usuario);
                    MessageBox.Show("Usuario modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}