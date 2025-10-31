using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class CarritoForm : Form
    {
        // Clase interna para mostrar datos en la grilla
        private class CarritoItemDetalle
        {
            public int ProductoId { get; set; }
            public string NombreProducto { get; set; }
            public decimal PrecioUnitario { get; set; }
            public int Cantidad { get; set; }
            public decimal Subtotal => PrecioUnitario * Cantidad;
        }

        private List<CarritoItemDetalle> _detallesEnGrilla = new List<CarritoItemDetalle>();

        public CarritoForm()
        {
            InitializeComponent();
        }

        private async void CarritoForm_Load(object sender, EventArgs e)
        {
            await CargarCarrito();
        }

        private async Task CargarCarrito()
        {
            try
            {
                var itemsEnCarrito = GestorDeSesion.Carrito.Items;
                _detallesEnGrilla.Clear();

                if (!itemsEnCarrito.Any())
                {
                    MessageBox.Show("El carrito está vacío.", "Carrito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    finalizarPedidoButton.Enabled = false;
                }
                else
                {
                    // Necesitamos buscar los detalles de cada producto
                    foreach (var item in itemsEnCarrito)
                    {
                        var producto = await ProductoApiClient.GetAsync(item.ProductoId);
                        _detallesEnGrilla.Add(new CarritoItemDetalle
                        {
                            ProductoId = item.ProductoId,
                            NombreProducto = producto.Nombre,
                            PrecioUnitario = producto.Precio,
                            Cantidad = item.Cantidad
                        });
                    }
                    finalizarPedidoButton.Enabled = true;
                }

                // Actualizar la grilla y el total
                carritoDataGridView.DataSource = null;
                carritoDataGridView.DataSource = _detallesEnGrilla;
                CalcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el carrito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularTotal()
        {
            var total = _detallesEnGrilla.Sum(item => item.Subtotal);
            totalLabel.Text = total.ToString("C"); // Formato de moneda
        }

        private PedidoDetalleDTO? ObtenerItemSeleccionado()
        {
            if (carritoDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un item del carrito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            var detalleGrilla = (CarritoItemDetalle)carritoDataGridView.SelectedRows[0].DataBoundItem;
            return GestorDeSesion.Carrito.Items.First(i => i.ProductoId == detalleGrilla.ProductoId);
        }

        private async void aumentarButton_Click(object sender, EventArgs e)
        {
            var item = ObtenerItemSeleccionado();
            if (item == null) return;

            GestorDeSesion.Carrito.AumentarCantidad(item.ProductoId);
            await CargarCarrito();
        }

        private async void disminuirButton_Click(object sender, EventArgs e)
        {
            var item = ObtenerItemSeleccionado();
            if (item == null) return;

            GestorDeSesion.Carrito.DisminuirCantidad(item.ProductoId);
            await CargarCarrito();
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            var item = ObtenerItemSeleccionado();
            if (item == null) return;

            GestorDeSesion.Carrito.RemoverDelCarrito(item.ProductoId);
            await CargarCarrito();
        }

        private async void finalizarPedidoButton_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Está seguro que desea finalizar el pedido?", "Confirmar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion != DialogResult.Yes) return;

            try
            {
                var pedidoDto = new PedidoDTO
                {
                    Detalles = GestorDeSesion.Carrito.Items
                };

                await PedidoApiClient.CrearPedidoAsync(pedidoDto);

                MessageBox.Show("¡Pedido creado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GestorDeSesion.Carrito.LimpiarCarrito();
                await CargarCarrito();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al finalizar el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}