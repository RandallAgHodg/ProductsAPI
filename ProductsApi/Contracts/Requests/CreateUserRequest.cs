namespace ProductsApi.Contracts.Requests;

public class CreateUserRequest
{
    public string Username { get; init; } = default;
    public string FullName { get; init; } = default;
    public string Password { get; init; } = default;
    public string Email { get; init; } = default!;
    public DateTime DateOfBirth { get; init; } = default!;
    public bool IsAdmin { get; init; } = false;
}