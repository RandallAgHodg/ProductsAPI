using FastEndpoints;
using ProductsApi.Endpoints;

namespace ProductsApi.Summaries;

public class DeleteProductSummary : Summary<DeleteProductEndpoint>
{
    public DeleteProductSummary()
    {
        Summary = "Delete a product in the system";
        Description = "Delete a product in the system";
        Response(204,  "The customer was deleted successfully");
        Response(404, "The customer was not found in the system");
    }
}