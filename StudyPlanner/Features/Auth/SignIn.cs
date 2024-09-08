using System.Security.Claims;
using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Identity;
using StudyPlanner.Data;

namespace StudyPlanner.Features.Auth;

internal sealed record SignInRequest(string Email, string Password);

internal sealed class SignIn: Endpoint<SignInRequest> 
{
    private readonly UserManager<ApplicationUser> _userManager;

    public SignIn(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public override void Configure()
    {
        Post("/auth/signin");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SignInRequest req, CancellationToken ct)
    {
        var user = await _userManager.FindByEmailAsync(req.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, req.Password))
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        // Get user roles and create claims
        var roles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, req.Email)
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        // Create and sign in the user
        await CookieAuth.SignInAsync(u =>
        {
            u.Claims.AddRange(claims);
            u.Roles.AddRange(roles);
        });

        await SendOkAsync(ct);
    
    }
}