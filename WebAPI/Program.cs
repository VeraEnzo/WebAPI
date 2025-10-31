using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Services;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<CategoriaService>();

// ---------- PASO 1: AÑADIR SERVICIO CORS ----------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorWasm",
        policy =>
        {
            policy.WithOrigins("https://localhost:7209", "http://localhost:5089")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
// -----------------------------------------------------

// ---------- 1. CONFIGURACIÓN DE SERVICIOS DE AUTENTICACIÓN Y AUTORIZACIÓN ----------
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"], // Lee el emisor desde appsettings

        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtSettings:Audience"], // Lee la audiencia desde appsettings

        ValidateLifetime = true, // Verifica que el token no haya expirado

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]!)), // Valida la firma usando la clave secreta

        ClockSkew = TimeSpan.Zero // Elimina la tolerancia de tiempo en la expiración del token
    };
});

builder.Services.AddAuthorization(options =>
{
    // Creamos una política llamada "Admin" que exige que el usuario tenga el rol "Admin".
    // Este rol es el que pusimos en el token JWT.
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});
// ------------------------------------------------------------------------------------

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

// ---------- PASO 2: USAR MIDDLEWARE CORS ----------
app.UseCors("AllowBlazorWasm");


// ---------- 2. ACTIVACIÓN DE MIDDLEWARES DE AUTENTICACIÓN Y AUTORIZACIÓN ----------
app.UseAuthentication();
app.UseAuthorization();
// ---------------------------------------------------------------------------------

//  app.UseAuthorization();
// app.MapControllers();

// --------------------------------------------------

// ---------- ORGANIZACIÓN DE ENDPOINTS ----------
app.MapProductoEndpoints();
app.MapUsuarioEndpoints();
app.MapPedidoEndpoints();
app.MapCategoriaEndpoints();
// -----------------------------------------------------------

app.Run();