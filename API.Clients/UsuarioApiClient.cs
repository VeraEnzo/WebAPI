using DTOs;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public static class UsuarioApiClient
    {
        private static readonly HttpClient client;

        static UsuarioApiClient()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:7153"); // Cambiar si tu API tiene otra URL
        }

        public static async Task<UsuarioDTO> ValidateAsync(string email, string contrasena)
        {
            try
            {
                var loginData = new
                {
                    Email = email,
                    Contrasena = contrasena
                };

                HttpResponseMessage response = await client.PostAsJsonAsync("/usuarios/login", loginData);

                if (response.IsSuccessStatusCode)
                {
                    var usuario = await response.Content.ReadFromJsonAsync<UsuarioDTO>();
                    return usuario ?? throw new Exception("Error inesperado: respuesta vacía del servidor.");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return null; // Credenciales inválidas
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error en login. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error de conexión al servidor de autenticación: " + ex.Message, ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception("Timeout al intentar validar el usuario: " + ex.Message, ex);
            }
        }
    }
}
