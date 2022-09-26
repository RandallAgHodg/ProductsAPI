using ValueOf;

namespace ProductsApi.Domain.Common;

public class UserId : ValueOf<Guid, UserId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
        {
            throw new ArgumentException("The user id is required", nameof(UserId));
        }
    }
}