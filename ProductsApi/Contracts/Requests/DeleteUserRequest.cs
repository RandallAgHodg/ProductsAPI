namespace ProductsApi.Contracts.Requests;

public class DeleteUserRequest
{
    public Guid Id { get; init; } = default!;
}