using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using StudyPlanner.Data;

namespace StudyPlanner.Features.Auth.MFA;

public class LoginWithMfaRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string VerificationCode { get; set; }
}

public class LoginWithMfaEndpoint : Endpoint<LoginWithMfaRequest>
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public LoginWithMfaEndpoint(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public override void Configure()
    {
        Post("/auth/mfa/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginWithMfaRequest req, CancellationToken ct)
    {
        var user = await _userManager.FindByEmailAsync(req.Email);
        if (user == null)
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        var result = await _signInManager.PasswordSignInAsync(user, req.Password, false, lockoutOnFailure: true);

        if (result.RequiresTwoFactor)
        {
            // Verify the TOTP code
            var isTokenValid = await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultAuthenticatorProvider, req.VerificationCode);
            if (!isTokenValid)
            {
                await SendUnauthorizedAsync(ct);
                return;
            }

            // Continue with sign-in
            await _signInManager.SignInAsync(user, isPersistent: false);
            await SendOkAsync("Login successful", ct);
        }
        else if (result.Succeeded)
        {
            await SendOkAsync("Login successful", ct);
        }
        else
        {
            await SendUnauthorizedAsync(ct);
        }
    }
}