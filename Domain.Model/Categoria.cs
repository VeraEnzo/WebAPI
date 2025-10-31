using System;

namespace Domain.Model
{
    public class Categoria
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public bool Activo { get; private set; }

        // Constructor privado para EF Core
        private Categoria() { }

        // Constructor para crear una NUEVA categoría (siempre activa)
        public Categoria(int id, string nombre, string descripcion)
        {
            SetNombre(nombre);
            SetDescripcion(descripcion);
            Activo = true; // Por defecto, una nueva categoría está activa
            Id = id;
        }

        // --- CONSTRUCTOR NUEVO (Paso 1) ---
        // Constructor para REHIDRATAR un objeto desde la base de datos (ADO.NET)
        public Categoria(int id, string nombre, string descripcion, bool activo)
        {
            SetNombre(nombre);
            SetDescripcion(descripcion);
            Activo = activo;
            Id = id;
        }
        // -----------------------------------

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la categoría no puede estar vacío.");
            Nombre = nombre;
        }

        public void SetDescripcion(string descripcion)
        {
            Descripcion = descripcion ?? string.Empty;
        }

        public void Desactivar()
        {
            Activo = false;
        }

        public void Activar()
        {
            Activo = true;
        }
    }
}