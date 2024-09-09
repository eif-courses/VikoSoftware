using FastEndpoints;
using System.Security.Claims;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Identity;
using StudyPlanner.Data;

namespace StudyPlanner.Features.Auth.MFA;

internal sealed record Verify2FaRequest(string UserId, string VerificationCode);

internal sealed class Verify2Fa : Endpoint<Verify2FaRequest>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public Verify2Fa(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public override void Configure()
    {
        Post("/auth/verify-2fa");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Verify2FaRequest req, CancellationToken ct)
    {
        var user = await _userManager.FindByIdAsync(req.UserId);
        if (user == null)
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        // Verify the 2FA code
        var isTokenValid = await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultAuthenticatorProvider, req.VerificationCode);
        if (!isTokenValid)
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        // Complete the sign-in process
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