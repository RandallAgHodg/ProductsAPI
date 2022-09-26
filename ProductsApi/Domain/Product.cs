using ProductsApi.Domain.Common;

namespace ProductsApi.Domain;

public class Product
{
    public ProductId Id { get; init; } = ProductId.From(Guid.NewGuid());
    public Name Name { get; init; } = default!;
    public Description Description { get; init; } = default!;
    public Stock Stock { get; init; } = default!;
    public Price Price { get; init; } = default!;
    public PictureUrl PictureUrl { get; set; } = default!;
    public InsertTimeStamp InsertTimeStamp { get; set; } = InsertTimeStamp.From(DateTime.Now);
    public UserId UserId { get; set; } = default!;
}