using ProductsApi.Contracts.Data;
using ProductsApi.Domain;
using ProductsApi.Domain.Common;

namespace ProductsApi.Mapping;

public static class DtoToDomainMapper
{
    public static Product ToProduct(this ProductDto productDto)
    {
        return new Product
        {
            Id = ProductId.From(productDto.Id),
            Name = Name.From(productDto.Name),
            Description = Description.From(productDto.Description),
            Price = Price.From(productDto.Price),
            Stock = Stock.From(productDto.Stock),
            PictureUrl = PictureUrl.From(productDto.PictureUrl),
        };
    }

    public static User ToUser(this UserDto userDto)
    {
        return new User
        {
            Id = UserId.From(userDto.Id),
            FullName = FullName.From(userDto.FullName),
            Username = Username.From(userDto.Username),
            Password = Password.From(userDto.Password),
            Email = EmailAddress.From(userDto.Email),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(userDto.DateOfBirth))
        };
    }
}