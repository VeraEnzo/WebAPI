using Application.Services;
using DTOs;
using Microsoft.Extensions.Configuration;

namespace WebAPI
{
    public static class UsuarioEndpoints
    {
        public static void MapUsuarioEndpoints(this WebApplication app)
        {
            // ---------- ENDPOINT LOGIN (Público) ----------
            app.MapPost("/usuarios/login", (UsuarioLoginDTO loginDTO, UsuarioService usuarioService, IConfiguration configuration) =>
            {
                var token = usuarioService.ValidarYGenerarToken(loginDTO.Email, loginDTO.Contrasena, configuration);
                if (token == null)
                {
                    return Results.Unauthorized();
                }
                return Results.Ok(new { Token = token });
            })
            .WithName("LoginUsuario")
            .Produces<object>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .WithOpenApi();

            // ---------- ENDPOINT REGISTRO PÚBLICO ----------
            app.MapPost("/usuarios/registro", (UsuarioDTO dto, UsuarioService usuarioService) =>
            {
                try
                {
                    // Forzamos que el nuevo usuario NO sea administrador por seguridad.
                    dto.EsAdmin = false;

                    var result = usuarioService.Add(dto);
                    // Devolvemos el usuario creado sin la contraseña.
                    result.Contrasena = "";
                    return Results.Created($"/usuarios/{result.Id}", result);
                }
                catch (ArgumentException ex)
                {
                    // Esto se dispara si el email ya existe.
                    return Results.BadRequest(new { error = ex.Message });
                }
                catch (Exception)
                {
                    // Error genérico por si algo más falla.
                    return Results.StatusCode(500);
                }
            })
            .WithName("RegistrarUsuario")
            .Produces<UsuarioDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi(); // No lleva .RequireAuthorization() porque es público.

            // ---------- ENDPOINTS CRUD DE USUARIOS (Protegidos) ----------

            app.MapGet("/usuarios", (UsuarioService usuarioService) =>
            {
                var usuarios = usuarioService.GetAll();
                return Results.Ok(usuarios);
            })
            .WithName("GetAllUsuarios")
            .Produces<List<UsuarioDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization("Admin"); // <-- Protegido con política "Admin"

            app.MapGet("/usuarios/{id}", (int id, UsuarioService usuarioService) =>
            {
                var usuario = usuarioService.Get(id);
                return usuario != null ? Results.Ok(usuario) : Results.NotFound();
            })
            .WithName("GetUsuarioById")
            .Produces<UsuarioDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("Admin"); // <-- Protegido

            app.MapPost("/usuarios", (UsuarioDTO dto, UsuarioService usuarioService) =>
            {
                try
                {
                    var result = usuarioService.Add(dto);
                    return Results.Created($"/usuarios/{result.Id}", result);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddUsuario")
            .Produces<UsuarioDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("Admin"); // <-- Protegido

            app.MapPut("/usuarios", (UsuarioDTO dto, UsuarioService usuarioService) =>
            {
                try
                {
                    bool updated = usuarioService.Update(dto);
                    return updated ? Results.NoContent() : Results.NotFound();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateUsuario")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("Admin"); // <-- Protegido

            app.MapDelete("/usuarios/{id}", (int id, UsuarioService usuarioService) =>
            {
                bool deleted = usuarioService.Delete(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteUsuario")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("Admin"); // <-- Protegido
        }
    }
}