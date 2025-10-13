using Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class ProductoRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Producto producto)
        {
            using var context = CreateContext();
            context.Productos.Add(producto);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var producto = context.Productos.Find(id);
            if (producto != null)
            {
                context.Productos.Remove(producto);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Producto? Get(int id)
        {
            using var context = CreateContext();
            return context.Productos.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Producto> GetAll()
        {
            using var context = CreateContext();
            return context.Productos.ToList();
        }

        public bool Update(Producto producto)
        {
            using var context = CreateContext();
            var existing = context.Productos.Find(producto.Id);
            if (existing != null)
            {
                existing.SetNombre(producto.Nombre);
                existing.SetDescripcion(producto.Descripcion);
                existing.SetPrecio(producto.Precio);
                existing.SetStock(producto.Stock);
                existing.CambiarCategoria(producto.CategoriaId);
                existing.CambiarProveedor(producto.ProveedorId);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool NombreExists(string nombre, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Productos.Where(p => p.Nombre.ToLower() == nombre.ToLower());

            if (excludeId.HasValue)
            {
                query = query.Where(p => p.Id != excludeId.Value);
            }

            return query.Any();
        }
    }
}