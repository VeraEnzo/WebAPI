using DTOs;
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
            client.BaseAddress = new Uri("https://localhost:7153");
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
        }

        public static async Task<UsuarioDTO> GetAsync(int id)
        {
            try
            {
                return await client.GetFromJsonAsync<UsuarioDTO>("usuarios/" + id);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener usuario con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<List<UsuarioDTO>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("/usuarios");
                if (response.IsSuccessStatusCode)
                {
                    var usuarios = await response.Content.ReadFromJsonAsync<List<UsuarioDTO>>();
                    return usuarios ?? new List<UsuarioDTO>();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener usuarios: {response.StatusCode} - {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error de conexión al servidor: " + ex.Message);
            }
        }

        // --- INICIO DE CÓDIGO NUEVO ---

        public static async Task<UsuarioDTO> AddAsync(UsuarioDTO usuario)
        {
            var response = await client.PostAsJsonAsync("/usuarios", usuario);
            if (response.IsSuccessStatusCode)
            {
                // La API devuelve el usuario creado (con su nuevo ID)
                return await response.Content.ReadFromJsonAsync<UsuarioDTO>();
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear el usuario: {error}");
            }
        }

        public static async Task<bool> UpdateAsync(UsuarioDTO usuario)
        {
            var response = await client.PutAsJsonAsync("/usuarios", usuario);
            // Devuelve true si la respuesta fue exitosa (ej. 204 No Content), false si no.
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            var response = await client.DeleteAsync($"/usuarios/{id}");
            // Devuelve true si la respuesta fue exitosa (ej. 204 No Content), false si no.
            return response.IsSuccessStatusCode;
        }

        // --- FIN DE CÓDIGO NUEVO ---
    }
}