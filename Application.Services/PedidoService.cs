using Data;
using Domain.Model;
using DTOs;

namespace Application.Services
{
    public class PedidoService
    {
        public void CrearPedido(PedidoDTO pedidoDto, int usuarioId)
        {
            var pedido = new Pedido(usuarioId);
            var productoRepository = new ProductoRepository();

            foreach (var item in pedidoDto.Detalles)
            {
                // Buscamos el producto en la BD para asegurar stock y precio
                var producto = productoRepository.Get(item.ProductoId);
                if (producto == null || producto.Stock < item.Cantidad)
                {
                    throw new Exception($"No hay stock suficiente para el producto ID {item.ProductoId}");
                }

                // Descontamos el stock
                producto.SetStock(producto.Stock - item.Cantidad);
                productoRepository.Update(producto);

                // Creamos el detalle del pedido
                var detalle = new PedidoDetalle(item.ProductoId, item.Cantidad, producto.Precio);
                pedido.Detalles.Add(detalle);
            }

            pedido.CalcularTotal();

            var pedidoRepository = new PedidoRepository(); // Necesitarás crear esta clase
            pedidoRepository.Add(pedido);
        }
        public List<PedidoResumenDTO> GetPedidosPorUsuario(int usuarioId)
        {
            var pedidoRepository = new PedidoRepository();
            var pedidos = pedidoRepository.GetByUsuarioId(usuarioId);

            // Mapeamos a DTO
            return pedidos.Select(p => new PedidoResumenDTO
            {
                Id = p.Id,
                FechaPedido = p.FechaPedido,
                UsuarioId = p.UsuarioId,
                Total = p.Total,
                CantidadItems = p.Detalles.Sum(d => d.Cantidad)
            }).ToList();
        }

        public List<PedidoResumenDTO> GetAllPedidos()
        {
            var pedidoRepository = new PedidoRepository();
            var usuarioRepository = new UsuarioRepository(); // Para obtener los nombres de usuario
            var pedidos = pedidoRepository.GetAll();
            var usuarios = usuarioRepository.GetAll();

            return pedidos.Select(p => new PedidoResumenDTO
            {
                Id = p.Id,
                FechaPedido = p.FechaPedido,
                UsuarioId = p.UsuarioId,
                NombreUsuario = usuarios.FirstOrDefault(u => u.Id == p.UsuarioId)?.Nombre ?? "N/A",
                Total = p.Total,
                CantidadItems = p.Detalles.Sum(d => d.Cantidad)
            }).ToList();
        }

        public List<PedidoDetalleItemDTO>? GetPedidoDetalle(int pedidoId, int solicitanteId, bool esAdmin)
        {
            var pedidoRepository = new PedidoRepository();
            var productoRepository = new ProductoRepository();
            var pedido = pedidoRepository.GetById(pedidoId);

            if (pedido == null) return null;

            // ¡Seguridad! Un usuario normal solo puede ver sus propios pedidos.
            if (!esAdmin && pedido.UsuarioId != solicitanteId)
            {
                return null; // O lanzar una excepción de no autorizado
            }

            var productos = productoRepository.GetAll().ToDictionary(p => p.Id);

            return pedido.Detalles.Select(d => new PedidoDetalleItemDTO
            {
                ProductoId = d.ProductoId,
                NombreProducto = productos.ContainsKey(d.ProductoId) ? productos[d.ProductoId].Nombre : "Producto no encontrado",
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario,
                Subtotal = d.Subtotal
            }).ToList();
        }
    }
}