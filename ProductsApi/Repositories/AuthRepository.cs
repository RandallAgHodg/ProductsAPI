using System.Data;
using Dapper;
using ProductsApi.Contracts.Data;
using ProductsApi.Database;

namespace ProductsApi.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly IDbConnectionFactory _connection;

    public AuthRepository(IDbConnectionFactory connection)
    {
        _connection = connection;
    }

    public async Task<bool> Register(UserDto userDto)
    {
        using var connection = await _connection.CreateConnectionAsync();
        const string procedure = "sp_insert_user";
        var result = await connection.ExecuteAsync(procedure, userDto, commandType: CommandType.StoredProcedure);
        return result > 0;
    }

    public async Task<UserDto?> GetAsync(Guid id)
    {
        using var connection = await _connection.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<UserDto>(
            "SELECT * FROM Users WHERE Id = @Id LIMIT 1",
            new { Id = id.ToString() });
    }

    public async Task<bool> UpdateAsync(UserDto userDto)
    {
        using var connection = await _connection.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            "UPDATE Users SET FirstName = @FirstName SET Username = @Username SET Email = @Email SET  DateOfBirth = @DateOfBirth SET RoleId = @RoleId WHERE Id = @Id",
            userDto);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        using var connection = await _connection.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            "DELETE FROM Users WHERE Id = @Id", new { Id = id.ToString() });
        return result > 0;
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        using var connection = await _connection.CreateConnectionAsync();
        var result = await connection.QuerySingleOrDefaultAsync(
            "SELECT * FROM Users WHERE Email = @Email", new {Email = email});
        return result is not null;
    }

    public async Task<UserDto?> FindByUsernameAsync(string username)
    {
        using var connection = await _connection.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<UserDto>(
            "SELECT * FROM Users WHERE Username = @Username LIMIT 1", new { Username = username });
        
    }

    public async Task<string?> GetPasswordByUsernameAsync(string username)
    {
        using var connection = await _connection.CreateConnectionAsync();
        var password = await connection.QuerySingleOrDefaultAsync<string>(
            "SELECT Password FROM Users WHERE Username = @Username", new { Username = username });
        return password;
    }
}