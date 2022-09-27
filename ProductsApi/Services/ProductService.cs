using FluentValidation;
using FluentValidation.Results;
using ProductsApi.Contracts.Data;
using ProductsApi.Domain;
using ProductsApi.Mapping;
using ProductsApi.Repositories;

namespace ProductsApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> CreateAsync(Product product)
    {
        var existingProduct = await _productRepository.GetAsync(product.Id.Value);
        if (existingProduct is not null)
        {
            var message = $"A product with id {product.Id} already exists";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Product), message)
            });
        }

        var productDto = product.ToProductDto();
        return await _productRepository.CreateAsync(productDto);
    }

    public async Task<Product?> GetAsync(Guid id)
    {
        var productDto = await _productRepository.GetAsync(id);
        return productDto?.ToProduct();
    }

    public async Task<IEnumerable<Product>> GetAllAsync(Guid userId)
    {
        var productsDto = await _productRepository.GetAllAsync(userId);
        return productsDto.Select(x => x.ToProduct());
    }

    public async Task<bool> UpdateAsync(Product product)
    {
        var productDto = product.ToProductDto();
        return await _productRepository.UpdateAsync(productDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _productRepository.DeleteAsync(id);
    }
}