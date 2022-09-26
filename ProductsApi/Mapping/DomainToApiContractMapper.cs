using ProductsApi.Contracts.Responses;
using ProductsApi.Domain;

namespace ProductsApi.Mapping;

public static class DomainToApiContractMapper
{
    public static ProductResponse ToProductResponse(this Product product)
    {
        return new ProductResponse
        {
            Id = product.Id.Value,
            Name = product.Name.Value,
            Description = product.Description.Value,
            Stock = product.Stock.Value,
            Price = product.Price.Value,
            PictureUrl = product.PictureUrl.Value
        };
    }

    public static GetAllProductsResponse ToProductsResponse(this IEnumerable<Product> products)
    {
        return new GetAllProductsResponse
        {
            Products = products.Select(product => new ProductResponse
            {
                Id = product.Id.Value,
                Name = product.Name.Value,
                Description = product.Description.Value,
                Stock = product.Stock.Value,
                Price = product.Price.Value,
                PictureUrl = product.PictureUrl.Value
            })
        };
    }
}