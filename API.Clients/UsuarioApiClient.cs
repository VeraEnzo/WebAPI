using DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers; // <-- Importante
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

        // --- MÉTODO NUEVO PARA AÑADIR EL TOKEN ---
        public static void ConfigurarToken(string? token)
        {
            client.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(token)
                ? null
                : new AuthenticationHeaderValue("Bearer", token);
        }

        // Clase auxiliar para leer la respuesta del login
        private class LoginResponse { public string Token { get; set; } = ""; }

        // --- MÉTODO DE LOGIN MODIFICADO (YA NO SE LLAMA VALIDATEASYNC) ---
        public static async Task<string?> LoginAsync(string email, string contrasena)
        {
            try
            {
                var loginData = new UsuarioLoginDTO { Email = email, Contrasena = contrasena };
                HttpResponseMessage response = await client.PostAsJsonAsync("/usuarios/login", loginData);

                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    return loginResponse?.Token; // Devuelve el string del token
                }
                else
                {
                    return null; // Credenciales inválidas o error
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Loguear el error
                return null;
            }
        }

        // --- MÉTODO NUEVO PARA REGISTRO PÚBLICO ---
        public static async Task<UsuarioDTO?> RegistroAsync(UsuarioDTO nuevoUsuario)
        {
            var response = await client.PostAsJsonAsync("/usuarios/registro", nuevoUsuario);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UsuarioDTO>();
            }
            else
            {
                // Leer el mensaje de error de la API (ej. email duplicado)
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error?["error"] ?? "Error al registrarse.");
            }
        }

        // --- MÉTODOS CRUD (Ahora funcionarán porque el token se añade en ConfigurarToken) ---

        public static async Task<UsuarioDTO> GetAsync(int id)
        {
            return await client.GetFromJsonAsync<UsuarioDTO>("usuarios/" + id);
        }

        public static async Task<List<UsuarioDTO>> GetAllAsync()
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

        public static async Task<UsuarioDTO> AddAsync(UsuarioDTO usuario)
        {
            var response = await client.PostAsJsonAsync("/usuarios", usuario);
            if (response.IsSuccessStatusCode)
            {
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
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            var response = await client.DeleteAsync($"/usuarios/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}