using Dapper;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using ProductsApi.Database;

namespace ProductsApi.Endpoints;

[HttpGet("products"), AllowAnonymous]
public class GetAllProductsEndpoint : EndpointWithoutRequest
{
    private readonly IDbConnectionFactory _connectionFactory;

    public GetAllProductsEndpoint(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.QueryAsync(
            "SELECT * FROM Products");
        await SendOkAsync(result, ct);
    }
}