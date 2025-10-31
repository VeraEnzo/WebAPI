using DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public static class PedidoApiClient
    {
        private static readonly HttpClient client;

        static PedidoApiClient()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:7153"); // Tu URL de API
        }

        public static void ConfigurarToken(string? token)
        {
            client.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(token)
                ? null
                : new AuthenticationHeaderValue("Bearer", token);
        }

        public static async Task<bool> CrearPedidoAsync(PedidoDTO pedido)
        {
            var response = await client.PostAsJsonAsync("pedidos", pedido);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error?["error"] ?? "Error al crear el pedido.");
            }
        }

        // --- MÉTODO NUEVO PARA USUARIOS NORMALES ---
        public static async Task<List<PedidoResumenDTO>> GetMisPedidosAsync()
        {
            return await client.GetFromJsonAsync<List<PedidoResumenDTO>>("pedidos/mis-pedidos");
        }

        // --- MÉTODO NUEVO PARA ADMINISTRADORES ---
        public static async Task<List<PedidoResumenDTO>> GetAllPedidosAsync()
        {
            return await client.GetFromJsonAsync<List<PedidoResumenDTO>>("pedidos");
        }

        // --- MÉTODO NUEVO PARA VER DETALLES ---
        public static async Task<List<PedidoDetalleItemDTO>> GetPedidoDetalleAsync(int pedidoId)
        {
            return await client.GetFromJsonAsync<List<PedidoDetalleItemDTO>>($"pedidos/{pedidoId}");
        }
    }
}