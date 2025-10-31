using API.Clients;
using DTOs;
using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void ingresarButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text.Trim();
            string contrasena = contrasenaTextBox.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Debe ingresar email y contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Llamamos al nuevo método de login que devuelve el token
                var token = await UsuarioApiClient.LoginAsync(email, contrasena);

                if (token != null)
                {
                    // 2. Iniciamos la sesión global
                    GestorDeSesion.IniciarSesion(token);

                    MessageBox.Show($"Bienvenido, {GestorDeSesion.NombreUsuario}!", "Login exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. Abrimos el formulario principal
                    // var formPrincipal = new MainForm();
                    // this.Hide();
                    // formPrincipal.ShowDialog();
                    // this.Close();

                    // 1. Avisamos que el login fue exitoso
                    this.DialogResult = DialogResult.OK;
                    // 2. Cerramos el formulario de login (pero no la aplicación)
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Email o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al conectar con el servidor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registrarButton_Click(object sender, EventArgs e)
        {
            // Creamos y mostramos el nuevo formulario de registro
            var formRegistro = new RegistroForm();
            formRegistro.ShowDialog();
            // No cerramos el login, el usuario vuelve aquí después de registrarse
        }
    }
}