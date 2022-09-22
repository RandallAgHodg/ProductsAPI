using ValueOf;

namespace ProductsApi.Domain.Common;

public class ProductId : ValueOf<Guid, ProductId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
        {
            throw new ArgumentException("The product id is required", nameof(ProductId));
        }
    }
}