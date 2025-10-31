using DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public static class CategoriaApiClient
    {
        private static readonly HttpClient client;

        static CategoriaApiClient()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:7153"); // Tu URL de API
        }

        // Método para que el GestorDeSesion configure el token
        public static void ConfigurarToken(string? token)
        {
            client.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(token)
                ? null
                : new AuthenticationHeaderValue("Bearer", token);
        }

        public static async Task<List<CategoriaDTO>> GetAllAsync()
        {
            try
            {
                // Este endpoint es público
                return await client.GetFromJsonAsync<List<CategoriaDTO>>("/categorias") ?? new List<CategoriaDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener categorías: {ex.Message}");
            }
        }

        public static async Task<CategoriaDTO> GetAsync(int id)
        {
            // Este requiere token de Admin
            return await client.GetFromJsonAsync<CategoriaDTO>($"/categorias/{id}");
        }

        public static async Task<CategoriaDTO> AddAsync(CategoriaDTO dto)
        {
            var response = await client.PostAsJsonAsync("/categorias", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CategoriaDTO>();
            }
            else
            {
                // Intentar leer el error de la API
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error?["error"] ?? "Error al crear la categoría.");
            }
        }

        public static async Task<bool> UpdateAsync(CategoriaDTO dto)
        {
            var response = await client.PutAsJsonAsync("/categorias", dto);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error?["error"] ?? "Error al actualizar la categoría.");
            }
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            // Este endpoint (DELETE /categorias/{id}) dispara el borrado lógico en la API
            var response = await client.DeleteAsync($"/categorias/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}