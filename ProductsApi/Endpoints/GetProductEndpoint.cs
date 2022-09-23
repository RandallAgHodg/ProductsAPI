using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using ProductsApi.Contracts.Requests;
using ProductsApi.Contracts.Responses;
using ProductsApi.Mapping;
using ProductsApi.Services;

namespace ProductsApi.Endpoints;

[HttpGet("products/{id:guid}"), AllowAnonymous]
public class GetProductEndpoint : Endpoint<GetProductRequest, ProductResponse>
{
    private readonly IProductService _productService;

    public GetProductEndpoint(IProductService productService)
    {
        _productService = productService;
    }

    public override async Task HandleAsync(GetProductRequest req, CancellationToken ct)
    {
        var product = await _productService.GetAsync(req.Id);

        if (product is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var productResponse = product.ToProductResponse();
        await SendOkAsync(productResponse, ct);
    }
}