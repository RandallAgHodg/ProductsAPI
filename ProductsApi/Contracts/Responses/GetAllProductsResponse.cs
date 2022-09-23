namespace ProductsApi.Contracts.Responses;

public class GetAllProductsResponse
{
    public IEnumerable<ProductResponse> Products { get; init; } = Enumerable.Empty<ProductResponse>();
}