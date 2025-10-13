using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Email { get; private set; }
        public string Contrasena { get; private set; }
        public DateTime FechaAlta { get; private set; }
        public bool EsAdmin { get; private set; }

        public Usuario(int id, string nombre, string apellido, string email, string contrasena, DateTime fechaAlta, bool esAdmin)
        {
            SetId(id);
            SetNombre(nombre);
            SetApellido(apellido);
            SetEmail(email);
            SetContrasena(contrasena);
            SetFechaAlta(fechaAlta);
            SetEsAdmin(esAdmin);
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede ser nulo o vacío.", nameof(apellido));
            Apellido = apellido;
        }

        public void SetEmail(string email)
        {
            if (!EsEmailValido(email))
                throw new ArgumentException("El email no tiene un formato válido.", nameof(email));
            Email = email;
        }

        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public void SetContrasena(string contrasena)
        {
            if (string.IsNullOrWhiteSpace(contrasena))
                throw new ArgumentException("La contraseña no puede ser nula o vacía.", nameof(contrasena));
            Contrasena = contrasena;
        }

        public void SetFechaAlta(DateTime fechaAlta)
        {
            FechaAlta = fechaAlta;
        }

        public void SetEsAdmin(bool esAdmin)
        {
            EsAdmin = esAdmin;
        }
    }
}
