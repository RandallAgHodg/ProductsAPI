using System.Security.Claims;
using Dapper;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using ProductsApi.Database;
using ProductsApi.Mapping;
using ProductsApi.Services;

namespace ProductsApi.Endpoints;

public class GetAllProductsEndpoint : EndpointWithoutRequest
{
    private readonly IProductService _productService;

    public GetAllProductsEndpoint(IProductService productService)
    {
        _productService = productService;
    }

    public override void Configure()
    {
        Get("products");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var userId = 
            Guid.Parse(HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
        var products = await _productService.GetAllAsync(userId);
        var productsResponse = products.ToProductsResponse();
        await SendOkAsync(productsResponse, ct);
    }
}