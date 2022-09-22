using ProductsApi.Contracts.Requests;
using ProductsApi.Domain;
using ProductsApi.Domain.Common;

namespace ProductsApi.Mapping;

public static class ApiContractToDomainMapper
{
    public static Product ToProduct(this CreateProductRequest request)
    {
        return new Product
        {
            Id = ProductId.From(Guid.NewGuid()),
            Name = Name.From(request.Name),
            Description = Description.From(request.Description),
            Stock = Stock.From(request.Stock),
            Price = Price.From(request.Price),
            PictureUrl = PictureUrl.From(request.Picture)
        };
    } 
    
    public static Product ToProduct(this UpdateProductRequest request)
    {
        return new Product
        {
            Id = ProductId.From(request.Id),
            Name = Name.From(request.Name),
            Description = Description.From(request.Description),
            Price = Price.From(request.Price),
            Stock = Stock.From(request.Stock),
        };
    }
}

