using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using StudyPlanner.Data;

namespace StudyPlanner.Features.Auth.Mfa;

internal sealed record SignInRequest(string Email, string Password);

internal sealed class SignIn(UserManager<ApplicationUser> userManager) : Endpoint<SignInRequest>
{
    public override void Configure()
    {
        Post("/auth/mfa/signin");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SignInRequest req, CancellationToken ct)
    {
        var user = await userManager.FindByEmailAsync(req.Email);
        if (user == null || !await userManager.CheckPasswordAsync(user, req.Password))
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        // Check if 2FA is enabled for this user
        if (!await userManager.GetTwoFactorEnabledAsync(user))
        {
            // Generate the QR code URL to set up 2FA
            var authenticatorKey = await userManager.GetAuthenticatorKeyAsync(user);
            if (string.IsNullOrEmpty(authenticatorKey))
            {
                await userManager.ResetAuthenticatorKeyAsync(user); // Reset key if needed
                authenticatorKey = await userManager.GetAuthenticatorKeyAsync(user);
            }

            // Generate the QR code URL
            var qrCodeUrl = $"otpauth://totp/VikoSoftware:{Uri.EscapeDataString(user.Email)}?secret={authenticatorKey}&issuer=VikoSoftware&digits=6";
            
            // Return the QR code URL to the frontend
            await SendAsync(new 
            { 
                message = "2FA setup required", 
                qrCodeUrl, 
                userId = user.Id 
            }, statusCode: 200, ct);
        }
        else
        {
            // If 2FA is already enabled, notify that 2FA is required
            await SendAsync(new { message = "2FA required", userId = user.Id }, statusCode: 200, ct);
        }
    }
}