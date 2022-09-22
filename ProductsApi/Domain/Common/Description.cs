using ValueOf;

namespace ProductsApi.Domain.Common;

public class Description : ValueOf<string, Description>
{
    protected override void Validate()
    {
        if (Value == string.Empty)
        {
            throw new ArgumentException("The product description is required", nameof(Description));
        }
    }
}