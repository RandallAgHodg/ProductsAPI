using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace ProductsApi.Domain.Common;

public class Password : ValueOf<string, Password>
{
    private static readonly Regex PasswordRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    protected override void Validate()
    {
        if (!PasswordRegex.IsMatch(Value))
        {
            const string message =
                "The password must be at least 8 characters long, must at least have one uppercase letter, " +
                "must at least have one lowercase letter, must at least have one digit, must at least hace" +
                "one special character";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Password), message)
            });
        }
    }
}