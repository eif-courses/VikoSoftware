using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace StudyPlanner.Features.Auth;

internal sealed class SignOut: EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/auth/mfa/signout");
        AuthSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await CookieAuth.SignOutAsync();
        await SendOkAsync(ct);
    }
}