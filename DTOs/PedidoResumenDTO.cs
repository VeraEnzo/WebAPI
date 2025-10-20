namespace DTOs
{
    public class PedidoResumenDTO
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; } = string.Empty; // Para mostrar en la vista de admin
        public decimal Total { get; set; }
        public int CantidadItems { get; set; }
    }
}