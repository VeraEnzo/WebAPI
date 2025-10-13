using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class UsuarioRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Usuario usuario)
        {
            using var context = CreateContext();
            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var usuario = context.Usuarios.Find(id);
            if (usuario != null)
            {
                context.Usuarios.Remove(usuario);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Usuario? Get(int id)
        {
            using var context = CreateContext();
            return context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            using var context = CreateContext();
            return context.Usuarios.ToList();
        }

        public bool Update(Usuario usuario)
        {
            using var context = CreateContext();
            var existing = context.Usuarios.Find(usuario.Id);
            if (existing != null)
            {
                existing.SetNombre(usuario.Nombre);
                existing.SetApellido(usuario.Apellido);
                existing.SetEmail(usuario.Email);
                existing.SetContrasena(usuario.Contrasena);
                existing.SetFechaAlta(usuario.FechaAlta);
                // Si quisieras cambiar el rol:
                existing.SetEsAdmin(usuario.EsAdmin);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EmailExists(string email, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Usuarios.Where(u => u.Email.ToLower() == email.ToLower());
            if (excludeId.HasValue)
                query = query.Where(u => u.Id != excludeId.Value);
            return query.Any();
        }

        public Usuario? Login(string email, string contrasena)
        {
            using var context = CreateContext();
            return context.Usuarios.FirstOrDefault(u =>
                u.Email.ToLower() == email.ToLower() &&
                u.Contrasena == contrasena);
        }
    }
}
