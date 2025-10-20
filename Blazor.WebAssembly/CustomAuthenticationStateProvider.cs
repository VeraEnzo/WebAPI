using API.Clients;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Blazor.WebAssembly;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IAuthService _authService;
    private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    public CustomAuthenticationStateProvider(IAuthService authService)
    {
        _authService = authService;

        // Escuchamos los eventos
        if (authService is BlazorWasmAuthService wasmAuthService)
        {
            wasmAuthService.OnLoginSuccess += (token) => NotifyUserAuthentication(token);
            wasmAuthService.OnLogoutSuccess += () => NotifyUserLogout();
        }
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var token = await _authService.GetTokenAsync();

            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(_anonymous);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var identity = new ClaimsIdentity(jwtToken.Claims, "jwtAuthType");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }
        catch
        {
            return new AuthenticationState(_anonymous);
        }
    }

    public void NotifyUserAuthentication(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);

        var identity = new ClaimsIdentity(jwtToken.Claims, "jwtAuthType");
        var user = new ClaimsPrincipal(identity);

        var authState = Task.FromResult(new AuthenticationState(user));
        NotifyAuthenticationStateChanged(authState);
    }

    public void NotifyUserLogout()
    {
        var authState = Task.FromResult(new AuthenticationState(_anonymous));
        NotifyAuthenticationStateChanged(authState);
    }
}