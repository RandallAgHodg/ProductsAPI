namespace ProductsApi.Contracts.Requests;

public class GetUserRequest
{
    public Guid Id { get; init; } = default!;
}