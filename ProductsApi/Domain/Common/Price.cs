using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace ProductsApi.Domain.Common;

public class Price : ValueOf<float, Price>
{
    protected override void Validate()
    {
        if (Value <= 0)
        {
            const string message = "The product`s price cannot be a negative value or zero";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Price), message)
            });
        }
    }
}