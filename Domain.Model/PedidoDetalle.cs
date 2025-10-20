namespace Domain.Model
{
    public class PedidoDetalle
    {
        public int Id { get; private set; }
        public int PedidoId { get; private set; } // A qué pedido pertenece
        public int ProductoId { get; private set; }
        public int Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; } // Guardamos el precio al momento de la compra
        public decimal Subtotal => Cantidad * PrecioUnitario;

        private PedidoDetalle() { } // Para EF Core

        public PedidoDetalle(int productoId, int cantidad, decimal precioUnitario)
        {
            ProductoId = productoId;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }
    }
}