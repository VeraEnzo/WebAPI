using Application.Services;
using DTOs;
using System.Security.Claims;

namespace WebAPI
{
    public static class PedidoEndpoints
    {
        public static void MapPedidoEndpoints(this WebApplication app)
        {
            app.MapPost("/pedidos", (PedidoDTO pedidoDto, PedidoService pedidoService, HttpContext httpContext) =>
            {
                try
                {
                    // Obtenemos el ID del usuario desde los "claims" del token JWT
                    var userIdClaim = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                    if (userIdClaim == null)
                    {
                        return Results.Unauthorized();
                    }

                    var usuarioId = int.Parse(userIdClaim.Value);

                    pedidoService.CrearPedido(pedidoDto, usuarioId);

                    return Results.Ok("Pedido creado exitosamente.");
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .RequireAuthorization(); // ¡Solo usuarios logueados pueden crear pedidos!

            // Endpoint para que un usuario vea SUS pedidos
            app.MapGet("/pedidos/mis-pedidos", (PedidoService pedidoService, HttpContext httpContext) =>
            {
                var userIdClaim = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim == null) return Results.Unauthorized();
                var usuarioId = int.Parse(userIdClaim.Value);

                return Results.Ok(pedidoService.GetPedidosPorUsuario(usuarioId));
            })
            .RequireAuthorization(); // Requiere estar logueado

            // Endpoint para que un ADMIN vea TODOS los pedidos
            app.MapGet("/pedidos", (PedidoService pedidoService) =>
            {
                return Results.Ok(pedidoService.GetAllPedidos());
            })
            .RequireAuthorization("Admin"); // Requiere ser Admin

            // Endpoint para ver el DETALLE de un pedido
            app.MapGet("/pedidos/{id:int}", (int id, PedidoService pedidoService, HttpContext httpContext) =>
            {
                var userIdClaim = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                var userRoleClaim = httpContext.User.FindFirst(ClaimTypes.Role);

                if (userIdClaim == null || userRoleClaim == null) return Results.Unauthorized();

                var solicitanteId = int.Parse(userIdClaim.Value);
                var esAdmin = userRoleClaim.Value == "Admin";

                var detalle = pedidoService.GetPedidoDetalle(id, solicitanteId, esAdmin);

                return detalle != null ? Results.Ok(detalle) : Results.NotFound("Pedido no encontrado o no tiene permisos para verlo.");
            })
            .RequireAuthorization(); // Requiere estar logueado
        }
    }
}