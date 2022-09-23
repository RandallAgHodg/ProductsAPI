using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace ProductsApi.Domain.Common;

public class PictureUrl : ValueOf<string, PictureUrl>
{
    private static readonly Regex UrlRegex =
        new(
            @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    protected override void Validate()
    {
        if (!UrlRegex.IsMatch(Value))
        {
            var message = $"{Value} is not a valid url";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(PictureUrl), message)
            });
        }
    }
}