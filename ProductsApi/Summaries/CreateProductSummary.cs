using FastEndpoints;
using ProductsApi.Contracts.Responses;
using ProductsApi.Endpoints;

namespace ProductsApi.Summaries;

public class CreateProductSummary : Summary<CreateProductEndpoint>
{
    public CreateProductSummary()
    {
        Description = "Creates a new product in the system";
        Summary = "Creates a new product in the system";
        Response<ProductResponse>(201, "Product was successfully created");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}