using ProductsApi.Contracts.Requests;
using ProductsApi.Domain;
using ProductsApi.Domain.Common;

namespace ProductsApi.Mapping;

public static class ApiContractToDomainMapper
{
    public static Product ToProduct(this CreateProductRequest request)
    {
        return new Product
        {
            Id = ProductId.From(Guid.NewGuid()),
            Name = Name.From(request.Name),
            Description = Description.From(request.Description),
            Stock = Stock.From(request.Stock),
            Price = Price.From(request.Price),
        };
    } 
    
    public static Product ToProduct(this UpdateProductRequest request)
    {
        return new Product
        {
            Id = ProductId.From(request.Id),
            Name = Name.From(request.Name),
            Description = Description.From(request.Description),
            Price = Price.From(request.Price),
            Stock = Stock.From(request.Stock),
        };
    }

    public static User ToUser(this CreateUserRequest request)
    {
        return new User
        {
            Id = UserId.From(Guid.NewGuid()),
            Username = Username.From(request.Username),
            FullName = FullName.From(request.FullName),
            Email = EmailAddress.From(request.Email),
            Password = Password.From(request.Password),
            RoleId = request.IsAdmin ? RoleId.From("ADMIN-USER") : RoleId.From( "NORMAL-USER"),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(request.DateOfBirth))
        };
    }
    
    public static User ToUser(this UpdateUserRequest request)
    {
        return new User
        {
            Id = UserId.From(request.Id),
            Username = Username.From(request.Username),
            FullName = FullName.From(request.FullName),
            Email = EmailAddress.From(request.Email),
        };
    }
}



