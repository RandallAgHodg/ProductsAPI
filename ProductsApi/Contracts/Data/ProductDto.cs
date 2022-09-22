namespace ProductsApi.Contracts.Data;

public class ProductDto
{
    public string Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public int Stock { get; init; } = default!;
    public float Price { get; init; } = default!;
    public string PictureUrl { get; init; } = default!;
    public DateTime InsertTimeStamp { get; init; } = default!;
}