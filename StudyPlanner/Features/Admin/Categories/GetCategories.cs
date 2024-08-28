using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using StudyPlanner.Data;
using StudyPlanner.Entities;

namespace StudyPlanner.Features.Admin.Categories;


internal sealed class GetCategoriesResponse
{
    public List<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();

}

internal sealed class GetCategories(ApplicationDbContext dbContext) : EndpointWithoutRequest<GetCategoriesResponse>
{
    public override void Configure()
    {
        Get("/admin/categories");
        Roles("Lecturer");
    }

    public override async Task HandleAsync(CancellationToken c)
    {
        if (!User.Identity.IsAuthenticated || !User.IsInRole("Lecturer"))
        {
            await SendUnauthorizedAsync(c);
            return;
        }

        var categories = await dbContext.Categories.ToListAsync(c);
        
        var response = new GetCategoriesResponse
        {
            Categories = categories
        };
        
        await SendAsync(response, cancellation: c);
    }
}
