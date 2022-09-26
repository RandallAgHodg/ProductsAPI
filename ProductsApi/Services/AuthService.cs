using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FastEndpoints.Security;
using FastEndpoints.Validation;
using FluentValidation;
using FluentValidation.Results;
using ProductsApi.Domain;
using ProductsApi.Domain.Common;
using ProductsApi.Mapping;
using ProductsApi.Repositories;

namespace ProductsApi.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IConfiguration _configuration;
    public AuthService(IAuthRepository authRepository, IConfiguration configuration)
    {
        _authRepository = authRepository;
        _configuration = configuration;
    }

    public async Task<string> Register(User user)
    {
        var existsUsername = await _authRepository.FindByUsernameAsync(user.Username.Value);
        var existsEmail = await _authRepository.ExistsByEmailAsync(user.Email.Value);
        if (existsEmail && existsUsername is not null)
        {
            const string message = "There is already a user with that email or username";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(User), message)
            });
        }
        var userDto = user.ToUserDto();
        userDto.Password = HashPassword(user.Password.Value);
        await _authRepository.Register(userDto);
        return await CreateToken(user.Username.Value);
    }

    public async Task<string> Login(string username, string password)
    {
        var isValidLogin = await CheckValidLogin(username, password);
        if (!isValidLogin)
        {
            const string message = "Username or password are not valid";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(User), message)
            });
        }

        return await CreateToken(username);
    }

    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public async Task<bool> CheckValidLogin(string username, string password)
    {
        var hashedPassword = await _authRepository.GetPasswordByUsernameAsync(username);
        return hashedPassword is not null && BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }

    public async Task<string> CreateToken(string username)
    {
        var user = await _authRepository.FindByUsernameAsync(username);
        var claims = new []
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim("username", user.Username),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var roles = new List<string>();
        
        if (user.RoleId == "ADMIN-USER") roles.Add("Admin");
        else roles.Add("Normal");

        return JWTBearer.CreateToken(
            signingKey: _configuration.GetValue<string>("jwt:SecretKey"),
            expireAt: DateTime.UtcNow.AddDays(60),
            claims: claims,
            roles: roles,
            issuer: _configuration.GetValue<string>("jw:Issuer"),
            audience: _configuration.GetValue<string>("jwt:Audience")
        );
    }
}