using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Mvc; // <-- Using añadido

namespace WebAPI
{
    public static class CategoriaEndpoints
    {
        public static void MapCategoriaEndpoints(this WebApplication app)
        {
            // GET para obtener todas las categorías (Público)
            app.MapGet("/categorias", ([FromServices] CategoriaService categoriaService) => // <-- [FromServices] añadido
            {
                return Results.Ok(categoriaService.GetAll());
            })
            .WithName("GetAllCategorias")
            .Produces<List<CategoriaDTO>>();

            // --- ENDPOINTS SOLO PARA ADMIN ---
            app.MapGet("/categorias/{id}", (int id, [FromServices] CategoriaService categoriaService) => // <-- [FromServices] añadido
            {
                var categoria = categoriaService.Get(id);
                return categoria != null ? Results.Ok(categoria) : Results.NotFound();
            })
            .WithName("GetCategoriaById")
            .Produces<CategoriaDTO>()
            .RequireAuthorization("Admin");

            // Para POST y PUT, el DTO viene del cuerpo (implícito), el servicio de DI ([FromServices])
            app.MapPost("/categorias", (CategoriaDTO dto, [FromServices] CategoriaService categoriaService) =>
            {
                try
                {
                    var result = categoriaService.Add(dto);
                    return Results.Created($"/categorias/{result.Id}", result);
                }
                catch (ArgumentException ex) // Error esperado (ej. nombre duplicado)
                {
                    // Devolvemos BadRequest con el mensaje específico
                    return Results.BadRequest(new { error = ex.Message });
                }
                catch (Exception ex) // Error inesperado (ej. problema con la base de datos)
                {
                    // --- CORREGIDO: Devolvemos InternalServerError con el mensaje ---
                    // Esto nos dará más información en la respuesta de Blazor
                    return Results.Problem(detail: ex.Message, statusCode: 500);
                    // -----------------------------------------------------------------
                }
            })
                        .WithName("AddCategoria")
            .Produces<CategoriaDTO>()
            .RequireAuthorization("Admin");

            app.MapPut("/categorias", (CategoriaDTO dto, [FromServices] CategoriaService categoriaService) => // <-- [FromServices] añadido
            {
                try
                {
                    var updated = categoriaService.Update(dto);
                    return updated ? Results.NoContent() : Results.NotFound();
                }
                catch (ArgumentException ex) { return Results.BadRequest(new { error = ex.Message }); }
            })
            .WithName("UpdateCategoria")
            .Produces(StatusCodes.Status204NoContent)
            .RequireAuthorization("Admin");

            app.MapDelete("/categorias/{id}", (int id, [FromServices] CategoriaService categoriaService) => // <-- [FromServices] añadido
            {
                var deleted = categoriaService.Delete(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteCategoria")
            .Produces(StatusCodes.Status204NoContent)
            .RequireAuthorization("Admin");

            app.MapGet("/categorias/buscar", ([FromServices] CategoriaService categoriaService, [FromQuery] string texto) =>
            {
                if (string.IsNullOrWhiteSpace(texto))
                {
                    return Results.Ok(categoriaService.GetAll()); // Si la búsqueda está vacía, devolver todo
                }
                return Results.Ok(categoriaService.Buscar(texto));
            })
            .WithName("BuscarCategorias")
            .Produces<List<CategoriaDTO>>()
            .RequireAuthorization("Admin");
        }
    }
}