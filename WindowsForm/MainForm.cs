using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Configuramos el formulario principal
            this.IsMdiContainer = true; // Opcional: para que los formularios se abran "dentro"
            this.WindowState = FormWindowState.Maximized;
            this.Text = $"TPI - Conectado como: {GestorDeSesion.Email}";

            // Controlamos la visibilidad de los menús según el rol
            administraciónToolStripMenuItem.Visible = GestorDeSesion.EsAdmin;
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de productos
            ProductoLista formProductos = new ProductoLista();
            formProductos.MdiParent = this; // Opcional: si usás MDI
            formProductos.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Creamos una instancia de tu formulario UsuarioLista
            UsuarioLista formUsuarios = new UsuarioLista();

            // Opcional: si querés que se abra "dentro" del formulario principal (MDI)
            formUsuarios.MdiParent = this;

            // Mostramos el formulario
            formUsuarios.Show();
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Creamos una instancia del nuevo formulario
            CategoriaLista formCategorias = new CategoriaLista();
            formCategorias.MdiParent = this; // Opcional
            formCategorias.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestorDeSesion.CerrarSesion();

            // Cerramos este formulario y volvemos al de Login
            // this.DialogResult = DialogResult.OK; // Señal para el LoginForm
            this.Close();

            // Esto se manejará en Program.cs para reiniciar la app
        }

        private void verCarritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario del carrito (que crearemos a continuación)
            CarritoForm formCarrito = new CarritoForm();
            formCarrito.MdiParent = this;
            formCarrito.Show();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario de historial de pedidos
            PedidosLista formPedidos = new PedidosLista();
            formPedidos.MdiParent = this;
            formPedidos.Show();
        }
    }
}