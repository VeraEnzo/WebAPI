using DTOs;
using System;
using System.Collections.Generic; // <-- Añadido por si faltaba
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public static class ProductoApiClient
    {
        private static readonly HttpClient client;

        static ProductoApiClient()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:7153"); // Asegúrate que sea tu URL
        }

        // --- MÉTODO NUEVO PARA AÑADIR EL TOKEN ---
        // Este método será llamado por el GestorDeSesion
        public static void ConfigurarToken(string? token)
        {
            client.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(token)
                ? null
                : new AuthenticationHeaderValue("Bearer", token);
        }
        // ----------------------------------------

        public static async Task<ProductoDTO> GetAsync(int id)
        {
            try
            {
                // Esta llamada ahora incluirá el token automáticamente
                HttpResponseMessage response = await client.GetAsync("productos/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ProductoDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener producto con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener producto con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener producto con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<List<ProductoDTO>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("/productos");
                if (response.IsSuccessStatusCode)
                {
                    var productos = await response.Content.ReadFromJsonAsync<List<ProductoDTO>>();
                    return productos ?? new List<ProductoDTO>();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener productos: {response.StatusCode} - {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error de conexión al servidor: " + ex.Message);
            }
        }

        public async static Task AddAsync(ProductoDTO producto)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("productos", producto);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear producto. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear producto: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear producto: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("productos/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar producto con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar producto con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar producto con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(ProductoDTO producto)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("productos", producto);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar producto con Id {producto.Id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar producto con Id {producto.Id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar producto con Id {producto.Id}: {ex.Message}", ex);
            }
        }
    }
}