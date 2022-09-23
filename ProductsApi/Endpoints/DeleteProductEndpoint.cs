using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using ProductsApi.Contracts.Requests;
using ProductsApi.Services;

namespace ProductsApi.Endpoints;

[HttpDelete("products/{id:guid}"), AllowAnonymous]
public class DeleteProductEndpoint : Endpoint<DeleteProductRequest>
{
    private readonly IProductService _productService;

    public DeleteProductEndpoint(IProductService productService)
    {
        _productService = productService;
    }

    public override async Task HandleAsync(DeleteProductRequest req, CancellationToken ct)
    {
        var deleted = await _productService.DeleteAsync(req.Id);
        
        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}