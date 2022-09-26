using System.Security.Claims;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using ProductsApi.Contracts.Requests;
using ProductsApi.Domain.Common;
using ProductsApi.Mapping;
using ProductsApi.Repositories;
using ProductsApi.Services;

namespace ProductsApi.Endpoints;

public class CreateProductEndpoint : Endpoint<CreateProductRequest>
{
    private readonly IProductService _productService;
    private readonly IFileStorerService _fileStorerService;
    public CreateProductEndpoint(IProductService productService, IFileStorerService fileStorerService)
    {
        _productService = productService;
        _fileStorerService = fileStorerService;
    }

    public override void Configure()
    {
        Post("/products");
        Policies("AdministratorsOnly");
        AllowFileUploads();
    }

    public override async Task HandleAsync(CreateProductRequest req, CancellationToken ct)
    {
        var image = req.Picture;
        
        var imageParams = new ImageUploadParams
        {
            File = new FileDescription(image.FileName, image.OpenReadStream()),
        };
        
        var pictureUrl = await _fileStorerService.UploadImage(imageParams);
        
        var product = req.ToProduct();
        
        product.PictureUrl = PictureUrl.From(pictureUrl);
        
        product.UserId =UserId.From(
            Guid.Parse(HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value));
        
        await _productService.CreateAsync(product);

        var productResponse = product.ToProductResponse();
        await SendCreatedAtAsync<GetProductEndpoint>(
            new { Id = product.Id.Value }, productResponse,
            generateAbsoluteUrl: true,
            cancellation: ct
        );
    }
}