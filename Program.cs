using Application.Services;
using DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

// ---------- ENDPOINTS PRODUCTOS ----------

app.MapGet("/productos", () =>
{
    ProductoService productoService = new ProductoService();

    var productos = productoService.GetAll();

    return Results.Ok(productos);
})
.WithName("GetAllProductos")
.Produces<List<ProductoDTO>>(StatusCodes.Status200OK)
.WithOpenApi();

app.MapGet("/productos/{id}", (int id) =>
{
    ProductoService productoService = new ProductoService();

    var producto = productoService.Get(id);

    if (producto == null)
        return Results.NotFound();

    return Results.Ok(producto);
})
.WithName("GetProductoById")
.Produces<ProductoDTO>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.MapPost("/productos", (ProductoDTO dto) =>
{
    try
    {
        ProductoService productoService = new ProductoService();

        var result = productoService.Add(dto);

        return Results.Created($"/productos/{result.Id}", result);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("AddProducto")
.Produces<ProductoDTO>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest)
.WithOpenApi();

app.MapPut("/productos", (ProductoDTO dto) =>
{
    try
    {
        ProductoService productoService = new ProductoService();

        bool updated = productoService.Update(dto);

        if (!updated)
            return Results.NotFound();

        return Results.NoContent();
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("UpdateProducto")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound)
.Produces(StatusCodes.Status400BadRequest)
.WithOpenApi();

app.MapDelete("/productos/{id}", (int id) =>
{
    ProductoService productoService = new ProductoService();

    bool deleted = productoService.Delete(id);

    if (!deleted)
        return Results.NotFound();

    return Results.NoContent();
})
.WithName("DeleteProducto")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

// -----------------------------------------

// ---------- ENDPOINT LOGIN USUARIO ----------

app.MapPost("/usuarios/login", (UsuarioLoginDTO loginDTO) =>
{
    var usuarioService = new UsuarioService();
    var usuario = usuarioService.Validar(loginDTO.Email, loginDTO.Contrasena);

    if (usuario == null)
        return Results.Unauthorized();

    // Podrías mapearlo a un DTO si no querés devolver toda la info
    return Results.Ok(usuario);
})
.WithName("LoginUsuario")
.Produces<UsuarioDTO>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status401Unauthorized)
.WithOpenApi();

// -----------------------------------------

app.Run();
