using FastEndpoints;
using ProductsApi.Contracts.Responses;
using ProductsApi.Endpoints;

namespace ProductsApi.Summaries;

public class GetAllProductsSummary: Summary<GetAllProductsEndpoint>
{
    public GetAllProductsSummary()
    {
        Summary = "Returns all the products in the system";
        Description = "Returns all the products in the system";
        Response<GetAllProductsResponse>(200, "All products in the system are returned");
        Response(401, "The action is lacking valid authentication");
        Response(403, "The action is forbidden for the current user");
    }
}