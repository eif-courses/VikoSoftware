using System.Security.Claims;
using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Identity;
using StudyPlanner.Data;

namespace StudyPlanner.Features.Auth;

public sealed record SignInRequest(string Email, string Password);

internal sealed class SignIn : Endpoint<SignInRequest>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public SignIn(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public override void Configure()
    {
        Post("/auth/mfa/signin");
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

        // Check if 2FA is enabled for this user
        if (await _userManager.GetTwoFactorEnabledAsync(user))
        {
            // Indicate that 2FA is required and send a temporary 2FA token
            // You can return a response with a 2FA-required status
            await SendAsync(new { message = "2FA required", userId = user.Id }, statusCode: 200, ct);
            return;
        }

        // No 2FA required, sign in the user with cookies
        await SignInUser(user);
        await SendOkAsync(ct);
    }

    private async Task SignInUser(ApplicationUser user)
    {
        // Get user roles and create claims
        var roles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        // Create and sign in the user using cookie authentication
        await CookieAuth.SignInAsync(u =>
        {
            u.Claims.AddRange(claims);
            u.Roles.AddRange(roles);
        });
    }
}