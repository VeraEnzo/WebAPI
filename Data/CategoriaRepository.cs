using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient; // <-- AÑADIDO: Necesario para ADO.NET
using Microsoft.Extensions.Configuration; // <-- AÑADIDO: Para leer la conexión
using System.IO; // <-- AÑADIDO: Para la ruta del appsettings

namespace Data
{
    public class CategoriaRepository
    {
        // --- Métodos de EF Core (Se mantienen como estaban) ---
        private TPIContext CreateContext() => new TPIContext();

        public void Add(Categoria categoria)
        {
            using var context = CreateContext();
            context.Categorias.Add(categoria);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var categoria = context.Categorias.Find(id);
            if (categoria != null)
            {
                categoria.Desactivar();
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Categoria? Get(int id)
        {
            using var context = CreateContext();
            return context.Categorias.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Categoria> GetAll()
        {
            using var context = CreateContext();
            return context.Categorias
                .Where(c => c.Activo)
                .OrderBy(c => c.Nombre)
                .ToList();
        }

        public bool Update(Categoria categoria)
        {
            using var context = CreateContext();
            var existing = context.Categorias.Find(categoria.Id);
            if (existing != null)
            {
                existing.SetNombre(categoria.Nombre);
                existing.SetDescripcion(categoria.Descripcion);

                if (categoria.Activo && !existing.Activo)
                    existing.Activar();
                else if (!categoria.Activo && existing.Activo)
                    existing.Desactivar();

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool NombreExists(string nombre, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Categorias.Where(c => c.Nombre.ToLower() == nombre.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }
            return query.Any();
        }

        // --- MÉTODO NUEVO CON ADO.NET (Paso 2) ---

        // Método para leer la Connection String (necesario para ADO.NET)
        private string GetConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            // Asegúrate de que el nombre "TPI_DB" coincida con tu appsettings.json
            return config.GetConnectionString("TPI_DB");
        }

        // Método de búsqueda con ADO.NET (Igual que el ejemplo de la cátedra)
        public IEnumerable<Categoria> GetByCriteria(string textoBusqueda)
        {
            const string sql = @"
                SELECT Id, Nombre, Descripcion, Activo
                FROM Categorias
                WHERE (Nombre LIKE @SearchTerm OR Descripcion LIKE @SearchTerm)
                  AND Activo = 1
                ORDER BY Nombre";

            var categorias = new List<Categoria>();
            string connectionString = GetConnectionString();
            string searchPattern = $"%{textoBusqueda}%";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var categoria = new Categoria(
                    reader.GetInt32(0),      // Id
                    reader.GetString(1),     // Nombre
                    reader.GetString(2),     // Descripcion
                    reader.GetBoolean(3)     // Activo
                );
                categorias.Add(categoria);
            }

            return categorias;
        }
        // --------------------------------------------------
    }
}