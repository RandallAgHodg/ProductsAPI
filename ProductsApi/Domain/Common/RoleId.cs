using ValueOf;

namespace ProductsApi.Domain.Common;

public class RoleId : ValueOf<string, RoleId>
{
    protected override void Validate()
    {
        if (Value == string.Empty)
        {
            throw new ArgumentException("The role id is required", nameof(RoleId));
        }
    }
}