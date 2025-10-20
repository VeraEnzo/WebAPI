using Domain.Model;
using Microsoft.EntityFrameworkCore; // <-- Asegúrate de tener este using
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class PedidoRepository
    {
        private TPIContext CreateContext() => new TPIContext();

        public void Add(Pedido pedido)
        {
            using var context = CreateContext();
            context.Pedidos.Add(pedido);
            context.SaveChanges();
        }

        public Pedido? GetById(int id)
        {
            using var context = CreateContext();
            // Include() le dice a EF que cargue también la lista de Detalles.
            // ThenInclude() carga los Productos dentro de cada Detalle.
            return context.Pedidos
                .Include(p => p.Detalles)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pedido> GetByUsuarioId(int usuarioId)
        {
            using var context = CreateContext();
            return context.Pedidos
                .Where(p => p.UsuarioId == usuarioId)
                .Include(p => p.Detalles)
                .OrderByDescending(p => p.FechaPedido)
                .ToList();
        }

        public IEnumerable<Pedido> GetAll()
        {
            using var context = CreateContext();
            return context.Pedidos
                .Include(p => p.Detalles)
                .OrderByDescending(p => p.FechaPedido)
                .ToList();
        }
    }
}