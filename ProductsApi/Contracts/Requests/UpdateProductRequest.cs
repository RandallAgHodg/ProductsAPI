namespace ProductsApi.Contracts.Requests;

public class UpdateProductRequest
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public int Stock { get; init; } = default!;
    public float Price { get; init; } = default!;
}