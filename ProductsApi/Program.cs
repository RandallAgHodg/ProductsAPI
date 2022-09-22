using FastEndpoints;
using FastEndpoints.Swagger;
using ProductsApi;
using ProductsApi.Contracts.Responses;
using ProductsApi.Database;
using ProductsApi.Repositories;
using ProductsApi.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
builder.Services.AddSingleton<IDbConnectionFactory>(_ => 
        new MySqlConnectionFactory(config.GetValue<string>("Database:ConnectionString"))
);

builder.Services.AddSingleton<DatabaseInitializer>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IProductService, ProductService>();

var app = builder.Build();

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
var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();
app.Run();