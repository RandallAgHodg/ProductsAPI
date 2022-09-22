namespace ProductsApi.Contracts.Responses;

public class ProductResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public int Stock { get; init; } = default!;
    public float Price { get; init; } = default!;
    public string PictureUrl { get; init; } = default!;
}