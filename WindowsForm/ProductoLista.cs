using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks; // <-- Importante para Task
using System.Windows.Forms;
// using Application.Services; // No es necesario si accedes al carrito vía GestorDeSesion

namespace WindowsForms
{
    public partial class ProductoLista : Form
    {
        // --- CONSTRUCTOR MODIFICADO ---
        // Ya no recibe parámetros, obtiene el estado del GestorDeSesion.
        public ProductoLista()
        {
            InitializeComponent();
        }

        // --- LOAD MODIFICADO ---
        private async void ProductoLista_Load(object sender, EventArgs e)
        {
            // Cargamos los productos y configuramos la visibilidad
            await CargarProductosAsync();
            ConfigurarVisibilidad();

            // Configurar el NumericUpDown (contador de cantidad)
            cantidadNumericUpDown.Minimum = 1;
            cantidadNumericUpDown.Value = 1;
            cantidadNumericUpDown.Maximum = 1000; // Límite por defecto
        }

        // --- NUEVO MÉTODO ---
        // Controla qué botones son visibles según el rol del usuario
        private void ConfigurarVisibilidad()
        {
            bool esAdmin = GestorDeSesion.EsAdmin;
            bool estaLogueado = GestorDeSesion.EstaLogueado;

            // Botones de Administrador
            agregarButton.Visible = esAdmin;
            modificarButton.Visible = esAdmin;
            eliminarButton.Visible = esAdmin;

            // Funcionalidad de Carrito (para todos los usuarios logueados)
            agregarAlCarritoButton.Visible = estaLogueado;
            cantidadNumericUpDown.Visible = estaLogueado;
        }

        // --- MÉTODO ACTUALIZADO (antes GetAllAndLoad) ---
        private async Task CargarProductosAsync()
        {
            try
            {
                this.productosDataGridView.DataSource = null;
                // La llamada a la API ya envía el token (configurado en GestorDeSesion)
                this.productosDataGridView.DataSource = await ProductoApiClient.GetAllAsync();
                ConfigurarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Si el error es 401 (No Autorizado), cerramos sesión
                if (ex.Message.Contains("401") || ex.Message.Contains("Unauthorized"))
                {
                    CerrarFormularioYVolverAlLogin();
                }
            }
        }

        private void ConfigurarGrilla()
        {
            // Ocultar columnas que no queremos ver
            if (productosDataGridView.Columns["Descripcion"] != null)
                productosDataGridView.Columns["Descripcion"].Visible = false;
            if (productosDataGridView.Columns["CategoriaId"] != null)
                productosDataGridView.Columns["CategoriaId"].Visible = false;
            if (productosDataGridView.Columns["ProveedorId"] != null)
                productosDataGridView.Columns["ProveedorId"].Visible = false;

            if (productosDataGridView.Columns["Id"] != null)
                productosDataGridView.Columns["Id"].Width = 50;

            // Ajustar botones si no hay filas
            bool hayFilas = this.productosDataGridView.Rows.Count > 0;
            if (hayFilas)
            {
                this.productosDataGridView.Rows[0].Selected = true;
            }

            modificarButton.Enabled = hayFilas;
            eliminarButton.Enabled = hayFilas;
            agregarAlCarritoButton.Enabled = hayFilas;
            cantidadNumericUpDown.Enabled = hayFilas;
        }

        // --- MÉTODO ACTUALIZADO (más seguro) ---
        private ProductoDTO? SelectedItem()
        {
            if (productosDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return (ProductoDTO)productosDataGridView.SelectedRows[0].DataBoundItem;
        }

        // --- LÓGICA DEL CARRITO (IMPLEMENTADA) ---
        private void agregarAlCarritoButton_Click(object sender, EventArgs e)
        {
            var producto = SelectedItem();
            if (producto == null) return; // SelectedItem ya mostró un error

            int cantidad = (int)cantidadNumericUpDown.Value;

            // Validaciones
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cantidad > producto.Stock)
            {
                MessageBox.Show($"No hay stock suficiente. Stock disponible: {producto.Stock}", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Usamos el CarritoService global desde GestorDeSesion
                GestorDeSesion.Carrito.AgregarAlCarrito(producto, cantidad);

                MessageBox.Show($"{cantidad} x '{producto.Nombre}' se ha(n) añadido al carrito.", "Carrito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cantidadNumericUpDown.Value = 1; // Reseteamos el contador
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar al carrito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Lógica de Admin (sin cambios, usando GetAllAndLoad renombrado) ---

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            ProductoDetalle productoDetalle = new ProductoDetalle();
            ProductoDTO productoNuevo = new ProductoDTO();
            productoDetalle.Mode = FormMode.Add;
            productoDetalle.Producto = productoNuevo;
            productoDetalle.ShowDialog();

            await CargarProductosAsync();
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            var productoSeleccionado = SelectedItem();
            if (productoSeleccionado == null) return;

            try
            {
                // Re-obtenemos el producto para asegurar datos frescos
                ProductoDTO producto = await ProductoApiClient.GetAsync(productoSeleccionado.Id);

                ProductoDetalle productoDetalle = new ProductoDetalle();
                productoDetalle.Mode = FormMode.Update;
                productoDetalle.Producto = producto;
                productoDetalle.ShowDialog();

                await CargarProductosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar producto para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            var producto = SelectedItem();
            if (producto == null) return;

            try
            {
                var result = MessageBox.Show($"¿Está seguro que desea eliminar el producto '{producto.Nombre}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await ProductoApiClient.DeleteAsync(producto.Id);
                    await CargarProductosAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- MÉTODO DE USUARIOS ELIMINADO ---
        // private void usuariosButton_Click(object sender, EventArgs e) { ... }

        // Método auxiliar para errores de autenticación
        private void CerrarFormularioYVolverAlLogin()
        {
            MessageBox.Show("Su sesión ha expirado o no tiene permisos. Por favor, inicie sesión nuevamente.", "Sesión Expirada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            GestorDeSesion.CerrarSesion();

            // Cerramos el formulario principal (MainForm) para forzar el reinicio
            if (this.MdiParent is Form mainForm)
            {
                mainForm.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}