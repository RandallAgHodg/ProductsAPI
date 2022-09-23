using FastEndpoints;
using ProductsApi.Contracts.Responses;
using ProductsApi.Endpoints;

namespace ProductsApi.Summaries;

public class UpdateProductSummary : Summary<UpdateProductEndpoint>
{
    public UpdateProductSummary()
    {
        Summary = "Updates an existing product in the system";
        Description = "Updates an existing product in the system";
        Response<ProductResponse>(201, "Product was successfully updated");
    }
}