using System.Globalization;
using Application.Services;
using Blazor.WebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7153/") });

// Registrar el servicio de autenticación desde Application.Services
builder.Services.AddScoped<AuthService>();

// Signo Pesos
var cultura = new CultureInfo("es-AR");
CultureInfo.DefaultThreadCurrentCulture = cultura;
CultureInfo.DefaultThreadCurrentUICulture = cultura;

await builder.Build().RunAsync();
