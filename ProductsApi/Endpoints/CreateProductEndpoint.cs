using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using ProductsApi.Contracts.Requests;
using ProductsApi.Mapping;
using ProductsApi.Repositories;
using ProductsApi.Services;

namespace ProductsApi.Endpoints;

[HttpPost("products"), AllowAnonymous]
public class CreateProductEndpoint : Endpoint<CreateProductRequest>
{
    private readonly IProductService _productService;

    public CreateProductEndpoint(IProductService productService)
    {
        _productService = productService;
    }

    public override async Task HandleAsync(CreateProductRequest req, CancellationToken ct)
    {
        var product = req.ToProduct();

        await _productService.CreateAsync(product);

        var productResponse = product.ToProductResponse();
        await SendCreatedAtAsync<GetProductEndpoint>(
            new { Id = product.Id.Value }, productResponse,
            generateAbsoluteUrl: true,
            cancellation: ct
        );
    }
}