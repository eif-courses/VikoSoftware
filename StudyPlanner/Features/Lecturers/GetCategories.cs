using System.Net;
using System.Security.Claims;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using StudyPlanner.Data;
using StudyPlanner.Entities;

namespace StudyPlanner.Features.Lecturers;


internal sealed class GetCategoriesResponse
{
    public List<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();

}


internal sealed class GetCategories(ApplicationDbContext dbContext) : EndpointWithoutRequest<GetCategoriesResponse>
{
    public override void Configure()
    {
        Get("/lecturers/categories");
        AuthSchemes(JwtBearerDefaults.AuthenticationScheme);
        
        // {
        //     "email": "eif@viko.lt",
        //     "password": "Kolegija1@"
        //
        // }
        
    }

    public override async Task HandleAsync(CancellationToken c)
    {
        // Check if the user is authenticated
        // if (!User.Identity.IsAuthenticated || !User.IsInRole("Lecturer"))
        // {
        //     await SendUnauthorizedAsync(c);
        //     return;
        // }

        // Extract the preferred_username from the JWT token
        var preferredUsername = User.Claims.FirstOrDefault(claim => claim.Type == "preferred_username")?.Value;

        if (string.IsNullOrEmpty(preferredUsername))
        {
            await SendUnauthorizedAsync(c);
            return;
        }

        // Log or use the preferred_username as needed
        Console.WriteLine($"Authenticated user preferred username: {preferredUsername}");

        // Fetch categories from the database
        var categories = await dbContext.Categories.ToListAsync(c);

        var response = new GetCategoriesResponse
        {
            Categories = categories
        };

        await SendAsync(response, cancellation: c);
    }
}
