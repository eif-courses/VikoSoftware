using System.Security.Claims;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using StudyPlanner.Data;

namespace StudyPlanner.Features.Auth.MFA;

public class EnableMfaRequest
{
    public string VerificationCode { get; set; }
}

public class EnableMfaEndpoint : Endpoint<EnableMfaRequest>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public EnableMfaEndpoint(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public override void Configure()
    {
        Post("/auth/mfa/enable");
        AuthSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
        //AllowAnonymous(); // Require authentication if appropriate
    }

    public override async Task HandleAsync(EnableMfaRequest req, CancellationToken ct)
    {
        
        // Get user ID from claims
        var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            Console.WriteLine("User is null or not authenticated.");
            await SendUnauthorizedAsync(ct);
            return;
        }
        
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        // Normalize verification code
        var verificationCode = req.VerificationCode.Replace(" ", string.Empty).Replace("-", string.Empty);

        // Verify the TOTP code
        var isTokenValid = await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultAuthenticatorProvider, verificationCode);
        if (!isTokenValid)
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        // Enable two-factor authentication
        await _userManager.SetTwoFactorEnabledAsync(user, true);

        await SendOkAsync("MFA enabled successfully", ct);
    }
}