using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace ProductsApi.Domain.Common;

public class Stock : ValueOf<int, Stock>
{
    protected override void Validate()
    {
        if (Value <= 0)
        {
            const string message = "The product stock cannot be a negative value or zero";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(Stock), message)
            });
        }
    }
}