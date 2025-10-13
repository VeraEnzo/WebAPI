using Data; // Asegúrate de tener este 'using'
using Domain.Model;
using DTOs;
using System.Collections.Generic; // Necesario para List<T>
using System.Linq; // Necesario para .Select()

namespace Application.Services
{
    public class ProductoService
    {
        public ProductoDTO Add(ProductoDTO dto)
        {
            var productoRepository = new ProductoRepository();

            if (productoRepository.NombreExists(dto.Nombre))
            {
                throw new ArgumentException($"Ya existe un producto con el nombre '{dto.Nombre}'.");
            }

            var producto = new Producto(0, dto.Nombre, dto.Descripcion, dto.Precio, dto.Stock, dto.CategoriaId, dto.ProveedorId);

            productoRepository.Add(producto);

            // La base de datos asigna el ID al objeto 'producto' después de guardarlo.
            dto.Id = producto.Id;
            return dto;
        }

        public List<ProductoDTO> GetAll()
        {
            // --- CORREGIDO ---
            // 1. Se crea una instancia del repositorio.
            var productoRepository = new ProductoRepository();
            // 2. Se llama al método GetAll() de la instancia.
            var productos = productoRepository.GetAll();

            // 3. Se mapean los objetos de dominio a DTOs para devolverlos.
            return productos.Select(p => new ProductoDTO
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

        public ProductoDTO? Get(int id)
        {
            // --- CORREGIDO ---
            var productoRepository = new ProductoRepository();
            var p = productoRepository.Get(id); // Se llama al método Get(id) de la instancia.

            if (p == null) return null;

            // Se mapea el objeto de dominio a un DTO.
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
            // --- CORREGIDO ---
            var productoRepository = new ProductoRepository();

            // La validación ahora excluye el ID del producto que se está editando.
            if (productoRepository.NombreExists(dto.Nombre, dto.Id))
            {
                throw new ArgumentException($"Ya existe otro producto con el nombre '{dto.Nombre}'.");
            }

            // Para actualizar, primero obtenemos la entidad de la base de datos.
            var producto = productoRepository.Get(dto.Id);
            if (producto == null)
            {
                return false; // No se puede actualizar un producto que no existe.
            }

            // Usamos los métodos del objeto de dominio para actualizar sus propiedades.
            producto.SetNombre(dto.Nombre);
            producto.SetDescripcion(dto.Descripcion);
            producto.SetPrecio(dto.Precio);
            producto.SetStock(dto.Stock);
            producto.CambiarCategoria(dto.CategoriaId);
            producto.CambiarProveedor(dto.ProveedorId);

            // Llamamos al método Update del repositorio.
            return productoRepository.Update(producto);
        }

        public bool Delete(int id)
        {
            // --- CORREGIDO ---
            var productoRepository = new ProductoRepository();
            // Simplemente llamamos al método Delete del repositorio.
            return productoRepository.Delete(id);
        }

        // El método GetNextId() se elimina porque la base de datos
        // se encarga de generar los IDs automáticamente.
    }
}