using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                var usuario = await UsuarioApiClient.ValidateAsync(email, contrasena);

                if (usuario != null)
                {
                    MessageBox.Show($"Bienvenido, {usuario.Nombre}!", "Login exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var formPrincipal = new ProductoLista();
                    this.Hide();
                    formPrincipal.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Email o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
