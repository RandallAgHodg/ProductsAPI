using ValueOf;

namespace ProductsApi.Domain.Common;

public class InsertTimeStamp : ValueOf<DateTime?, InsertTimeStamp>
{
    protected override void Validate()
    {
        if (Value is null)
        {
            throw new ArgumentException("The insert timestamp is required", nameof(InsertTimeStamp));
        }
    }
}