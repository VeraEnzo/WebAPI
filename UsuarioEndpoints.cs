using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class UsuarioEndpoints
    {
        public static void MapUsuarioEndpoints(this WebApplication app)
        {
            // ---------- ENDPOINT LOGIN ----------
            // Se inyecta 'usuarioService' como parámetro.
            app.MapPost("/usuarios/login", (UsuarioLoginDTO loginDTO, UsuarioService usuarioService) =>
            {
                var usuario = usuarioService.Validar(loginDTO.Email, loginDTO.Contrasena);

                if (usuario == null)
                    return Results.Unauthorized();

                return Results.Ok(usuario);
            })
            .WithName("LoginUsuario")
            .Produces<UsuarioDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .WithOpenApi();


            // ---------- ENDPOINTS CRUD DE USUARIOS ----------

            // GET para obtener todos los usuarios
            app.MapGet("/usuarios", (UsuarioService usuarioService) =>
            {
                var usuarios = usuarioService.GetAll();
                return Results.Ok(usuarios);
            })
            .WithName("GetAllUsuarios")
            .Produces<List<UsuarioDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            // GET para obtener un usuario por ID
            app.MapGet("/usuarios/{id}", (int id, UsuarioService usuarioService) =>
            {
                var usuario = usuarioService.Get(id);

                if (usuario == null)
                    return Results.NotFound();

                return Results.Ok(usuario);
            })
            .WithName("GetUsuarioById")
            .Produces<UsuarioDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            // POST para crear un nuevo usuario
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
            .WithOpenApi();

            // PUT para actualizar un usuario existente
            app.MapPut("/usuarios", (UsuarioDTO dto, UsuarioService usuarioService) =>
            {
                try
                {
                    bool updated = usuarioService.Update(dto);

                    if (!updated)
                        return Results.NotFound();

                    return Results.NoContent();
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
            .WithOpenApi();

            // DELETE para eliminar un usuario
            app.MapDelete("/usuarios/{id}", (int id, UsuarioService usuarioService) =>
            {
                bool deleted = usuarioService.Delete(id);

                if (!deleted)
                    return Results.NotFound();

                return Results.NoContent();
            })
            .WithName("DeleteUsuario")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}