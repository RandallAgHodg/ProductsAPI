using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using ProductsApi.Contracts.Requests;
using ProductsApi.Contracts.Responses;
using ProductsApi.Mapping;
using ProductsApi.Services;

namespace ProductsApi.Endpoints;

[HttpPut("products/{id:guid}"), AllowAnonymous]
public class UpdateProductEndpoint : Endpoint<UpdateProductRequest, ProductResponse>
{
    private readonly IProductService _productService;

    public UpdateProductEndpoint(IProductService productService)
    {
        _productService = productService;
    }

    public override async Task HandleAsync(UpdateProductRequest req, CancellationToken ct)
    {
        var existingProduct = await _productService.GetAsync(req.Id);

        if (existingProduct is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var product = req.ToProduct();
        await _productService.UpdateAsync(product);
        var productResponse = product.ToProductResponse();
        await SendOkAsync(productResponse, ct);
    }
}