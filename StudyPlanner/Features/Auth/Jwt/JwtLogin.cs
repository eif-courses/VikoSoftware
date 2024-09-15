using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace StudyPlanner.Features.Auth.Jwt;

[AllowAnonymous]
[HttpPost("/login/jwt")]
public class JwtLoginEndpoint : Endpoint<LoginRequest, LoginResponse>
{
    
    private IConfiguration _configuration;

    public JwtLoginEndpoint(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        // Perform user validation here (e.g., check email and password)

        // Generate JWT token (example code for demonstration)
        var token = GenerateJwtToken(req.Email);

        await SendAsync(new LoginResponse { Token = token }, cancellation: ct);
    }

    private string GenerateJwtToken(string email)
    {
        var jwtSettings = _configuration.GetSection("Authentication:Jwt");
        
        // Create security key from the secret
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));

        // Create signing credentials using the security key
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Define the claims
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, email),
            new Claim(JwtRegisteredClaimNames.Jti, Ulid.NewUlid().ToString()), // Unique token ID
            new Claim(ClaimTypes.Name, email) // Custom claim with user's email
        };

        // Create the JWT token
        var token = new JwtSecurityToken(
            issuer: jwtSettings["Authority"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30), // Token expiration time
            signingCredentials: credentials
        );

        // Serialize the token to string
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginResponse
{
    public string Token { get; set; }
}