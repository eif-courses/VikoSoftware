using FastEndpoints;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using SkiaSharp;
using StudyPlanner.Data;
using SkiaSharp.QrCode;
using SkiaSharp.QrCode.Models;

namespace StudyPlanner.Features.Auth.MFA;

public class QrCodeRequest
{
    public string Email { get; set; }
}

// Endpoint for generating QR code
public sealed class GenerateQrCodeEndpoint : Endpoint<QrCodeRequest>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public GenerateQrCodeEndpoint(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public override void Configure()
    {
        Get("/auth/mfa/qrcode");
        AuthSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public override async Task HandleAsync(QrCodeRequest req, CancellationToken ct)
    {
        var user = await _userManager.FindByEmailAsync(req.Email);
        if (user == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var authenticatorKey = await _userManager.GetAuthenticatorKeyAsync(user);
        if (string.IsNullOrEmpty(authenticatorKey))
        {
            await _userManager.ResetAuthenticatorKeyAsync(user);
            authenticatorKey = await _userManager.GetAuthenticatorKeyAsync(user);
        }

        var qrCodeUrl =
            $"otpauth://totp/VikoSoftware:{Uri.EscapeDataString(user.Email)}?secret={authenticatorKey}&issuer=VikoSoftware&digits=6";

        
        await SendOkAsync(qrCodeUrl, ct);
        
    }
}