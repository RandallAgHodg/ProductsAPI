using ProductsApi.Domain.Common;

namespace ProductsApi.Domain;

public class User
{
    public UserId Id { get; init; } = UserId.From(Guid.NewGuid());
    public Username Username { get; init; } = default!;
    public FullName FullName { get; init; } = default!;
    public EmailAddress Email { get; init; } = default!;
    public Password Password { get; set; } = default!;
    public DateOfBirth DateOfBirth { get; init; } = default!;
    public RoleId RoleId { get; init; } = default!;
}