using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public class Pedido
    {
        public int Id { get; private set; }
        public DateTime FechaPedido { get; private set; }
        public int UsuarioId { get; private set; } // Quién hizo el pedido
        public decimal Total { get; private set; }
        public List<PedidoDetalle> Detalles { get; private set; } = new();

        private Pedido() { } // Para EF Core

        public Pedido(int usuarioId)
        {
            if (usuarioId <= 0)
                throw new ArgumentException("El ID de usuario es inválido.");

            UsuarioId = usuarioId;
            FechaPedido = DateTime.UtcNow;
        }

        public void CalcularTotal()
        {
            Total = Detalles.Sum(d => d.Subtotal);
        }
    }
}