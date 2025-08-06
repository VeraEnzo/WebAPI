using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UsuarioInMemory
    {
        //No es ThreadSafe pero sirve para el proposito del ejemplo        
        public static List<Usuario> Usuarios;

        static UsuarioInMemory()
        {
            Usuarios = new List<Usuario>
            {
                new Usuario(1, "Juan", "Pérez", "juan.perez@email.com", "1234", DateTime.Now.AddMonths(-5)),
                new Usuario(2, "María", "Gómez", "maria.gomez@email.com", "1234", DateTime.Now.AddMonths(-4)),
                new Usuario(3, "Carlos", "López", "carlos.lopez@email.com", "1234", DateTime.Now.AddMonths(-3)),
                new Usuario(4, "Ana", "Martínez", "ana.martinez@email.com", "1234", DateTime.Now.AddMonths(-2)),
                new Usuario(5, "Lucía", "Fernández", "lucia.fernandez@email.com", "1234", DateTime.Now.AddMonths(-1))
            };
        }

    }
}
