using ValueOf;

namespace ProductsApi.Domain.Common;

public class Name : ValueOf<string, Name>
{
    protected override void Validate()
    {
        if (Value == string.Empty)
        {
            throw new ArgumentException("The product name is required", nameof(Name));
        }
    }
}