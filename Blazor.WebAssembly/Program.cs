using System.Globalization;
using Application.Services;
using Blazor.WebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using API.Clients;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// HttpClient simple
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7153/")
});

// Registrar servicios de autenticación
builder.Services.AddScoped<IAuthService, BlazorWasmAuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

// Servicios de autorización
builder.Services.AddAuthorizationCore();

// Registrar el servicio de autenticación y de carrito desde Application.Services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CarritoService>();

// Signo Pesos
var cultura = new CultureInfo("es-AR");
CultureInfo.DefaultThreadCurrentCulture = cultura;
CultureInfo.DefaultThreadCurrentUICulture = cultura;

var host = builder.Build();

// Inicializar el AuthService con el token almacenado
var authService = host.Services.GetRequiredService<IAuthService>();
if (authService is BlazorWasmAuthService wasmAuthService)
{
    await wasmAuthService.InitializeAsync();
}

await host.RunAsync();