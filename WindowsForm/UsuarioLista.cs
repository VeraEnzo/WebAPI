using API.Clients;
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
    public partial class UsuarioLista : Form
    {
        public UsuarioLista()
        {
            InitializeComponent();
        }
        private void UsuarioLista_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }
        private async void GetAllAndLoad()
        {
            try
            {
                this.usuariosDataGridView.DataSource = null;
                this.usuariosDataGridView.DataSource = await UsuarioApiClient.GetAllAsync();

                if (this.usuariosDataGridView.Rows.Count > 0)
                {
                    this.usuariosDataGridView.Rows[0].Selected = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
