using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class ProductoEndpoints
    {
        public static void MapProductoEndpoints(this WebApplication app)
        {
            // ---------- ENDPOINTS PRODUCTOS ----------

            app.MapGet("/productos", (ProductoService productoService) =>
            {
                var productos = productoService.GetAll();
                return Results.Ok(productos);
            })
            .WithName("GetAllProductos")
            .Produces<List<ProductoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization(); // <-- Requiere cualquier usuario logueado

            app.MapGet("/productos/{id}", (int id, ProductoService productoService) =>
            {
                var producto = productoService.Get(id);
                if (producto == null)
                    return Results.NotFound();
                return Results.Ok(producto);
            })
            .WithName("GetProductoById")
            .Produces<ProductoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization(); // <-- Requiere cualquier usuario logueado

            app.MapPost("/productos", (ProductoDTO dto, ProductoService productoService) =>
            {
                try
                {
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
            .WithOpenApi()
            .RequireAuthorization("Admin"); // <-- Usa la política "Admin"

            app.MapPut("/productos", (ProductoDTO dto, ProductoService productoService) =>
            {
                try
                {
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
            .WithOpenApi()
            .RequireAuthorization("Admin"); // <-- Usa la política "Admin"

            app.MapDelete("/productos/{id}", (int id, ProductoService productoService) =>
            {
                bool deleted = productoService.Delete(id);
                if (!deleted)
                    return Results.NotFound();
                return Results.NoContent();
            })
            .WithName("DeleteProducto")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("Admin"); // <-- Usa la política "Admin"
        }
    }
}