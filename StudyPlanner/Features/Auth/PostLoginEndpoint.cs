using FastEndpoints;

namespace StudyPlanner.Features.Auth;

public class PostLoginEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    { 
        Get("/post-login");
        AllowAnonymous(); // Ensure that the user is authenticated
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var user = HttpContext.User;

        // Example: Retrieve user's name and email from claims
        var name = user.FindFirst(c => c.Type == "name")?.Value;
        var email = user.FindFirst(c => c.Type == "email")?.Value;

        // Custom logic after login (e.g., create/update a user in your database)

        // Respond to the client
        await SendAsync(new
        {
            Message = "Login successful",
            Name = name,
            Email = email
        });
    }
}