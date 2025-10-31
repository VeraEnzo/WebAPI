using API.Clients;
using DTOs;
using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class RegistroForm : Form
    {
        public RegistroForm()
        {
            InitializeComponent();
        }

        private async void guardarButton_Click(object sender, EventArgs e)
        {
            // 1. Validaciones
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text) ||
                string.IsNullOrWhiteSpace(apellidoTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                string.IsNullOrWhiteSpace(contrasenaTextBox.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contrasenaTextBox.Text != confirmarContrasenaTextBox.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Crear el DTO
            var nuevoUsuario = new UsuarioDTO
            {
                Nombre = nombreTextBox.Text.Trim(),
                Apellido = apellidoTextBox.Text.Trim(),
                Email = emailTextBox.Text.Trim(),
                Contrasena = contrasenaTextBox.Text
                // La API se encarga de poner EsAdmin = false y la FechaAlta
            };

            // 3. Llamar a la API
            try
            {
                var usuarioRegistrado = await UsuarioApiClient.RegistroAsync(nuevoUsuario);
                if (usuarioRegistrado != null)
                {
                    MessageBox.Show("¡Usuario registrado exitosamente! Ya puede iniciar sesión.", "Registro completo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Mostramos el error de la API (ej. email duplicado)
                MessageBox.Show(ex.Message, "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}