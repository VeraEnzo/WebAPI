using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Application.Services; // <-- AÑADIDO: Para CarritoService

namespace WindowsForms
{
    // Esta clase estática mantendrá la sesión del usuario para toda la app
    public static class GestorDeSesion
    {
        public static string? Token { get; private set; }
        public static bool EsAdmin { get; private set; }
        public static string? NombreUsuario { get; private set; }
        public static string? Email { get; private set; }
        public static int UsuarioId { get; private set; }
        public static CarritoService Carrito { get; private set; }
        public static bool EstaLogueado => Token != null;

        public static void IniciarSesion(string token)
        {
            Token = token;

            // Decodificar el token para obtener los claims (roles, nombre, etc.)
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            // Extraer información del token
            NombreUsuario = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            Email = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var idClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var rolClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            EsAdmin = rolClaim == "Admin";
            int.TryParse(idClaim, out int id);
            UsuarioId = id;

            // Configurar los clientes de API para que usen este token
            API.Clients.UsuarioApiClient.ConfigurarToken(token);
            API.Clients.ProductoApiClient.ConfigurarToken(token);
            API.Clients.CategoriaApiClient.ConfigurarToken(token);
            API.Clients.PedidoApiClient.ConfigurarToken(token);

            // Creamos un nuevo carrito para esta sesión
            Carrito = new CarritoService();
        }

        public static void CerrarSesion()
        {
            Token = null;
            EsAdmin = false;
            NombreUsuario = null;
            Email = null;
            UsuarioId = 0;

            // Limpiar los tokens de los clientes
            API.Clients.UsuarioApiClient.ConfigurarToken(null);
            API.Clients.ProductoApiClient.ConfigurarToken(null);
            API.Clients.CategoriaApiClient.ConfigurarToken(null);
            API.Clients.PedidoApiClient.ConfigurarToken(null);

            // Descartamos el carrito
            Carrito = new CarritoService(); // Creamos uno nuevo vacío
        }
    }
}