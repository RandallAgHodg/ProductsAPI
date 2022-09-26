using ProductsApi.Contracts.Data;
using ProductsApi.Domain;

namespace ProductsApi.Repositories;

public interface IAuthRepository
{
    Task<bool> Register (UserDto userDto);
    Task<UserDto?> GetAsync(Guid id);
    Task<bool> UpdateAsync(UserDto userDto);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ExistsByEmailAsync (string email);
    Task<UserDto?> FindByUsernameAsync(string username);
    Task<string?> GetPasswordByUsernameAsync(string username);
}