using DTOs;
using System.Net.Http.Json;

namespace Application.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private UsuarioDTO? _usuarioActual;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public UsuarioDTO? UsuarioActual => _usuarioActual;
        public bool EstaAutenticado => _usuarioActual != null;
        public bool EsAdministrador => _usuarioActual?.EsAdmin ?? false;
        public bool EsInvitado => _usuarioActual?.Email == "invitado";

        public event Action? OnAuthStateChanged;

        public async Task<bool> Login(string email, string contrasena, bool requiereAdmin)
        {
            try
            {
                var loginData = new
                {
                    Email = email,
                    Contrasena = contrasena
                };

                var response = await _httpClient.PostAsJsonAsync("/usuarios/login", loginData);

                if (response.IsSuccessStatusCode)
                {
                    var usuario = await response.Content.ReadFromJsonAsync<UsuarioDTO>();

                    if (usuario != null)
                    {
                        // Si requiere admin pero el usuario no lo es, rechazar
                        if (requiereAdmin && !usuario.EsAdmin)
                        {
                            return false;
                        }

                        _usuarioActual = usuario;
                        OnAuthStateChanged?.Invoke();
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en login: {ex.Message}");
                return false;
            }
        }

        public void LoginComoInvitado()
        {
            _usuarioActual = new UsuarioDTO
            {
                Email = "invitado",
                Nombre = "Invitado",
                EsAdmin = false
            };
            OnAuthStateChanged?.Invoke();
        }

        public void Logout()
        {
            _usuarioActual = null;
            OnAuthStateChanged?.Invoke();
        }
    }
}