namespace API.Clients
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string email, string contrasena);
        Task LogoutAsync();
        Task<string?> GetTokenAsync();
        Task<bool> IsAuthenticatedAsync();
        Task InitializeAsync(); // AGREGAR ESTA LÍNEA
    }
}