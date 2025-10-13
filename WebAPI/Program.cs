using Application.Services;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<UsuarioService>();

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

//  app.UseAuthorization();

// app.MapControllers();
// --------------------------------------------------

// ---------- ORGANIZACIÓN DE ENDPOINTS ----------
app.MapProductoEndpoints();
app.MapUsuarioEndpoints();
// -----------------------------------------------------------

app.Run();