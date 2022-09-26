using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using ProductsApi.Contracts.Requests;
using ProductsApi.Contracts.Responses;
using ProductsApi.Services;

namespace ProductsApi.Endpoints;

[HttpPost("user/login"), AllowAnonymous]
public class LoginEndpoint : Endpoint<UserLoginRequest, AuthResponse>
{
    private readonly IAuthService _authService;

    public LoginEndpoint(IAuthService authService)
    {
        _authService = authService;
    }
    
    public override async Task HandleAsync(UserLoginRequest req, CancellationToken ct)
    {
        var token = await _authService.Login(req.Username, req.Password);
        await SendOkAsync(new AuthResponse
        {
            Token = token
        }, ct);
    }
}