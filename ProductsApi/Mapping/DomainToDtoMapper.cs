using ProductsApi.Contracts.Data;
using ProductsApi.Domain;

namespace ProductsApi.Mapping;

public static class DomainToDtoMapper
{
    public static ProductDto ToProductDto(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id.Value,
            Name = product.Name.Value,
            Description = product.Description.Value,
            Stock = product.Stock.Value,
            Price = product.Price.Value,
            PictureUrl = product.PictureUrl.Value,
            UserId = product.UserId.Value
        };
    }

    public static UserDto ToUserDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id.Value,
            FullName = user.FullName.Value,
            Username = user.Username.Value,
            Password = user.Password.Value,
            Email = user.Email.Value,
            RoleId = user.RoleId.Value,
            DateOfBirth = user.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue)
        };
    }
}