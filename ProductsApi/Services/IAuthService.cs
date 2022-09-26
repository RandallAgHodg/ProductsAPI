using ProductsApi.Domain;

namespace ProductsApi.Services;

public interface IAuthService
{
    Task<string> Register (User user);
    Task<string> Login (string username, string password);
    string HashPassword (string password);
    Task<bool> CheckValidLogin (string username, string password);
    Task<string> CreateToken(string username);
}