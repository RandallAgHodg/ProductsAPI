using FastEndpoints;
using ProductsApi.Contracts.Responses;
using ProductsApi.Endpoints;

namespace ProductsApi.Summaries;

public class GetProductSummary : Summary<GetProductEndpoint>
{
    public GetProductSummary()
    {
        Summary = "Returns a single product by id";
        Description = "Returns a single product by id";
        Response<GetAllProductsResponse>(200, "Successfully found and returned the the product");
        Response(404, "The product does not exists in the system");
    }
}