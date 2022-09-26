using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using ProductsApi.Contracts.Requests;
using ProductsApi.Contracts.Responses;
using ProductsApi.Mapping;
using ProductsApi.Services;

namespace ProductsApi.Endpoints;

[HttpPost("user/register"), AllowAnonymous]
public class CreateUserEndpoint : Endpoint<CreateUserRequest, AuthResponse>
{
    private readonly IAuthService _authService;

    public CreateUserEndpoint(IAuthService authService)
    {
        _authService = authService;
    }

    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        var user = req.ToUser();
        var result = await _authService.Register(user);
        await SendOkAsync(new AuthResponse
        {
            Token = result
        }, ct);
    }
}