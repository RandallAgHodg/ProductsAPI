using System.Data;
using Dapper;
using ProductsApi.Contracts.Data;
using ProductsApi.Database;

namespace ProductsApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnectionFactory _connection;

    public ProductRepository(IDbConnectionFactory connection)
    {
        _connection = connection;
    }

    public async Task<bool> CreateAsync(ProductDto product)
    {
        
        using var connection = await _connection.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO Products (Id, Name, Description, Stock, Price, PictureUrl, UserId)
                    VALUES (@Id, @Name, @Description, @Stock, @Price, @PictureUrl, @UserId)", product);
        return result > 0;
    }

    public async Task<ProductDto?> GetAsync(Guid id)
    {
        using var connection = await _connection.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<ProductDto>(
            "SELECT * FROM Products WHERE Id = @Id LIMIT 1",
            new {Id = id.ToString()});
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync(Guid userId)
    {
        using var connection = await _connection.CreateConnectionAsync();
        const string procedure = "sp_get_products_by_user";
        return await connection.QueryAsync<ProductDto>
            (procedure, 
                new {_userId = userId.ToString()}, 
                commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> UpdateAsync(ProductDto product)
    {
        using var connection = await _connection.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"UPDATE Products SET Name = @Name SET Description = @Description SET Stock = @Stock SET Price = @Price WHERE Id = @Id",
            product);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        using var connection = await _connection.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(@"DELETE FROM Products WHERE Id = @Id", new { Id = id.ToString() });
        return result > 0;
    }
}