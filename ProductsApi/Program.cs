using CloudinaryDotNet;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using ProductsApi;
using ProductsApi.Contracts.Responses;
using ProductsApi.Database;
using ProductsApi.Repositories;
using ProductsApi.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

var cloudSecret = config.GetValue<string>("Cloudinary:CloudSecret");
var cloudApiKey = config.GetValue<string>("Cloudinary:CloudApiKey");
var cloudName = config.GetValue<string>("Cloudinary:CloudName");

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
Console.WriteLine(config.GetValue<string>("jwt:SecretKey"));
builder.Services.AddAuthenticationJWTBearer(config.GetValue<string>("jwt:SecretKey"));
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton(
                new Cloudinary(new Account(cloudName, cloudApiKey, cloudSecret))
                );
builder.Services.AddSingleton<IFileStorerService, FileStorerService>();
builder.Services.AddSingleton<IDbConnectionFactory>(_ => 
        new MySqlConnectionFactory(config.GetValue<string>("Database:ConnectionString"))
);
builder.Services.AddSingleton<DatabaseInitializer>();
builder.Services.AddSingleton<IAuthRepository, AuthRepository>();
builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdministratorsOnly", 
        x => x.RequireRole("Admin")
        );
});

var app = builder.Build();
var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseFastEndpoints(x =>
{
    x.ErrorResponseBuilder = (failure, _) =>
    {
        return new ValidationFailureResponse
        {
            Errors = failure.Select(y => y.ErrorMessage).ToList()
        };
    };
});
app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());
app.Run();