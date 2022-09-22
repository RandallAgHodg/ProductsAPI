using ProductsApi.Contracts.Data;
using ProductsApi.Domain;
using ProductsApi.Domain.Common;

namespace ProductsApi.Mapping;

public static class DomainToDtoMapper
{
    public static ProductDto ToProductDto(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id.Value.ToString(),
            Name = product.Name.Value,
            Description = product.Description.Value,
            Stock = product.Stock.Value,
            Price = product.Price.Value,
            PictureUrl = product.PictureUrl.Value
        };
    }
}