using Domain.Model;
using DTOs;
using Data;

namespace Application.Services
{
    public class ProductoService
    {
        public ProductoDTO Add(ProductoDTO dto)
        {
            if (ProductoInMemory.Productos.Any(p => p.Nombre.Equals(dto.Nombre, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Ya existe un producto con el nombre '{dto.Nombre}'.");
            }

            int nuevoId = GetNextId();

            var producto = new Producto(
                nuevoId,
                dto.Nombre,
                dto.Descripcion,
                dto.Precio,
                dto.Stock,
                dto.CategoriaId,
                dto.ProveedorId
            );

            ProductoInMemory.Productos.Add(producto);

            dto.Id = producto.Id;
            return dto;
        }

        public List<ProductoDTO> GetAll()
        {
            return ProductoInMemory.Productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                Stock = p.Stock,
                CategoriaId = p.CategoriaId,
                ProveedorId = p.ProveedorId
            }).ToList();
        }

        public ProductoDTO Get(int id)
        {
            var p = ProductoInMemory.Productos.Find(p => p.Id == id);
            if (p == null) return null;

            return new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                Stock = p.Stock,
                CategoriaId = p.CategoriaId,
                ProveedorId = p.ProveedorId
            };
        }

        public bool Update(ProductoDTO dto)
        {
            var p = ProductoInMemory.Productos.Find(p => p.Id == dto.Id);
            if (p == null) return false;

            if (ProductoInMemory.Productos.Any(prod => prod.Id != dto.Id && prod.Nombre.Equals(dto.Nombre, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Ya existe otro producto con el nombre '{dto.Nombre}'.");
            }

            p.SetNombre(dto.Nombre);
            p.SetDescripcion(dto.Descripcion);
            p.SetPrecio(dto.Precio);
            p.SetStock(dto.Stock);
            p.CambiarCategoria(dto.CategoriaId);
            p.CambiarProveedor(dto.ProveedorId);

            return true;
        }

        public bool Delete(int id)
        {
            var p = ProductoInMemory.Productos.Find(p => p.Id == id);
            if (p == null) return false;

            ProductoInMemory.Productos.Remove(p);
            return true;
        }

        private static int GetNextId()
        {
            return ProductoInMemory.Productos.Count > 0
                ? ProductoInMemory.Productos.Max(p => p.Id) + 1
                : 1;
        }
    }
}
