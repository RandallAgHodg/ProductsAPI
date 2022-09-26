namespace ProductsApi.Contracts.Data;

public class UserDto
{
    public Guid Id { get; init; } = default!;
    public string Username { get; init; } = default;
    public string FullName { get; init; } = default;
    public string Password { get; set; }
    public string Email { get; init; } = default!;
    public DateTime DateOfBirth { get; init; } = default!;
    public string RoleId { get; init; } = default!;
}