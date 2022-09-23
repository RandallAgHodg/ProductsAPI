using ProductsApi.Contracts.Data;
using ProductsApi.Domain;
using ProductsApi.Domain.Common;

namespace ProductsApi.Mapping;

public static class DtoToDomainMapper
{
    public static Product ToProduct(this ProductDto productDto)
    {
        return new Product
        {
            Id = ProductId.From(Guid.Parse(productDto.Id)),
            Name = Name.From(productDto.Name),
            Description = Description.From(productDto.Description),
            Price = Price.From(productDto.Price),
            Stock = Stock.From(productDto.Stock),
            PictureUrl = PictureUrl.From(productDto.PictureUrl),
        };
    }
}