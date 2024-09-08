using System.Security.Claims;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace StudyPlanner.Features.Auth.User;


internal sealed class GetUserRoles : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/auth/user/roles");
        AuthSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        var userRoles = HttpContext.User.FindAll(ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();

        return SendAsync(new { Roles = userRoles }, cancellation: ct);
    }
}