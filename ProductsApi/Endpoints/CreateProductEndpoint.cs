using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using ProductsApi.Contracts.Requests;
using ProductsApi.Mapping;
using ProductsApi.Repositories;

namespace ProductsApi.Endpoints;

[HttpPost("products"), AllowAnonymous]
public class CreateProductEndpoint : Endpoint<CreateProductRequest>
{
    private readonly IProductRepository _repository;

    public CreateProductEndpoint(IProductRepository repository)
    {
        _repository = repository;
    }

    public override async Task HandleAsync(CreateProductRequest req, CancellationToken ct)
    {
        var result = await _repository.CreateAsync(req.ToProduct().ToProductDto());

        await SendOkAsync("nya", ct);
    }
}