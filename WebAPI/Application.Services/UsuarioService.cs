using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class UsuarioService
    {
        // Método de validación para login
        public UsuarioDTO? Validar(string email, string contrasena)
        {
            var usuario = UsuarioInMemory.Usuarios
                .FirstOrDefault(u => u.Email == email && u.Contrasena == contrasena);

            if (usuario == null)
                return null;

            // Mapeo manual a DTO (también podrías usar AutoMapper si querés)
            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Contrasena = usuario.Contrasena,
                FechaAlta = usuario.FechaAlta
            };
        }

        // -----------------------------------------------
        // Los siguientes métodos se pueden comentar si no los vas a usar por ahora
        /*
        public void Add(Usuario usuario)
        {
            usuario.SetId(GetNextId());
            usuario.SetFechaAlta(DateTime.Now);

            UsuarioInMemory.Usuarios.Add(usuario);
        }

        public bool Delete(int id)
        {
            Usuario? UsuarioToDelete = UsuarioInMemory.Usuarios.Find(x => x.Id == id);

            if (UsuarioToDelete != null)
            {
                UsuarioInMemory.Usuarios.Remove(UsuarioToDelete);
                return true;
            }
            else
            {
                return false;
            }
        }


        public Usuario Get(int id)
        {
            return UsuarioInMemory.Usuarios.Find(x => x.Id == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return UsuarioInMemory.Usuarios.ToList();
        }

        public bool Update(Usuario Usuario)
        {
            Usuario? UsuarioToUpdate = UsuarioInMemory.Usuarios.Find(x => x.Id == Usuario.Id);

            if (UsuarioToUpdate != null)
            {
                UsuarioToUpdate.SetNombre(Usuario.Nombre);
                UsuarioToUpdate.SetApellido(Usuario.Apellido);
                UsuarioToUpdate.SetEmail(Usuario.Email);

                return true;
            }
            else
            {
                return false;
            }
        }

        private static int GetNextId()
        {
            int nextId;

            if (UsuarioInMemory.Usuarios.Count > 0)
            {
                nextId = UsuarioInMemory.Usuarios.Max(x => x.Id) + 1;
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }
        */
        // -----------------------------------------------
    }
}
