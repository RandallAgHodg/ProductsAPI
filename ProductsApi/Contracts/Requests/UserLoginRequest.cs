namespace ProductsApi.Contracts.Requests;

public class UserLoginRequest
{
    public string Username { get; init; } = default!;
    public string Password { get; init; } = default!;
}