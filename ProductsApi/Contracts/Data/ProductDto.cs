namespace ProductsApi.Contracts.Data;

public class ProductDto
{
    public Guid Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public int Stock { get; init; }
    public float Price { get; init; }
    public string PictureUrl { get; init; } = default!;
    public DateTime InsertTimeStamp { get; init; }
    public Guid UserId { get; init; } = default!;
}