using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Producto
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public decimal Precio { get; private set; }
        public int Stock { get; private set; }
        public int CategoriaId { get; private set; }
        public int ProveedorId { get; private set; }

        public Producto(int id, string nombre, string descripcion, decimal precio, int stock, int categoriaId, int proveedorId)
        {
            SetNombre(nombre);
            SetDescripcion(descripcion);
            SetPrecio(precio);
            SetStock(stock);
            CategoriaId = categoriaId;
            ProveedorId = proveedorId;
            Id = id;
        }

        // Métodos para modificar con validaciones de negocio
        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");
            Nombre = nombre;
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.");
            Descripcion = descripcion;
        }

        public void SetPrecio(decimal precio)
        {
            if (precio < 0)
                throw new ArgumentException("El precio no puede ser negativo.");
            Precio = precio;
        }

        public void SetStock(int stock)
        {
            if (stock < 0)
                throw new ArgumentException("El stock no puede ser negativo.");
            Stock = stock;
        }

        public void CambiarCategoria(int categoriaId)
        {
            CategoriaId = categoriaId;
        }

        public void CambiarProveedor(int proveedorId)
        {
            ProveedorId = proveedorId;
        }

        // Constructor privado para Entity Framework Core
        private Producto() { }
    }
}
