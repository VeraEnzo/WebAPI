using API.Clients;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.IdentityModel.Tokens.Jwt;

namespace Blazor.WebAssembly;

public class BlazorWasmAuthService : IAuthService
{
    private readonly IJSRuntime _jsRuntime;
    private readonly HttpClient _httpClient;
    private const string TOKEN_KEY = "auth_token";

    public event Action<string>? OnLoginSuccess;
    public event Action? OnLogoutSuccess;

    private class LoginResponse
    {
        public string Token { get; set; } = "";
    }

    public BlazorWasmAuthService(IJSRuntime jsRuntime, HttpClient httpClient)
    {
        _jsRuntime = jsRuntime;
        _httpClient = httpClient;
    }

    public async Task<string?> GetTokenAsync()
    {
        try
        {
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", TOKEN_KEY);

            // Validar si el token ha expirado
            if (!string.IsNullOrEmpty(token) && IsTokenExpired(token))
            {
                // Token expirado, eliminarlo automáticamente
                await LogoutAsync();
                return null;
            }

            return token;
        }
        catch
        {
            return null;
        }
    }

    private bool IsTokenExpired(string token)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            // Verificar si el token ha expirado
            // ValidTo ya está en UTC, comparamos con DateTime.UtcNow
            return jwtToken.ValidTo < DateTime.UtcNow;
        }
        catch
        {
            // Si hay algún error al leer el token, considerarlo expirado
            return true;
        }
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        var token = await GetTokenAsync();
        return !string.IsNullOrEmpty(token);
    }

    public async Task<bool> LoginAsync(string email, string contrasena)
    {
        try
        {
            var loginRequest = new { Email = email, Contrasena = contrasena };
            var response = await _httpClient.PostAsJsonAsync("usuarios/login", loginRequest);

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();

                if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.Token))
                {
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", TOKEN_KEY, loginResponse.Token);

                    // Configurar el token para todas las peticiones futuras
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", loginResponse.Token);

                    OnLoginSuccess?.Invoke(loginResponse.Token);
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

    public async Task LogoutAsync()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", TOKEN_KEY);
        _httpClient.DefaultRequestHeaders.Authorization = null;
        OnLogoutSuccess?.Invoke();
    }

    // Método para cargar el token al iniciar la aplicación
    public async Task InitializeAsync()
    {
        var token = await GetTokenAsync();
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }
}