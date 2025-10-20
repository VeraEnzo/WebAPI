using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class CarritoService
    {
        public List<PedidoDetalleDTO> Items { get; private set; } = new();

        // 1. El evento que notificará los cambios
        public event Action? OnChange;

        public int TotalItems => Items.Sum(item => item.Cantidad);

        public void AgregarAlCarrito(ProductoDTO producto, int cantidad)
        {
            if (cantidad <= 0) return; // No agregar si la cantidad es cero o negativa

            var itemExistente = Items.FirstOrDefault(i => i.ProductoId == producto.Id);
            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                Items.Add(new PedidoDetalleDTO { ProductoId = producto.Id, Cantidad = cantidad });
            }
            NotificarCambio();
        }

        public void AumentarCantidad(int productoId)
        {
            var item = Items.FirstOrDefault(i => i.ProductoId == productoId);
            if (item != null)
            {
                item.Cantidad++;
                NotificarCambio();
            }
        }

        public void DisminuirCantidad(int productoId)
        {
            var item = Items.FirstOrDefault(i => i.ProductoId == productoId);
            if (item != null)
            {
                item.Cantidad--;
                if (item.Cantidad <= 0)
                {
                    Items.Remove(item);
                }
                NotificarCambio();
            }
        }

        public void RemoverDelCarrito(int productoId)
        {
            var item = Items.FirstOrDefault(i => i.ProductoId == productoId);
            if (item != null)
            {
                Items.Remove(item);
                NotificarCambio();
            }
        }

        public void LimpiarCarrito()
        {
            Items.Clear();
            NotificarCambio();
        }

        // 3. El método que dispara el evento
        private void NotificarCambio() => OnChange?.Invoke();
    }
}