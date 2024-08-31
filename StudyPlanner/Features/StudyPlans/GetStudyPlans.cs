using FastEndpoints;
using StudyPlanner.Data;
using StudyPlanner.Features.Admin.Categories;

namespace StudyPlanner.Features.StudyPlans;


internal sealed record StudyPlanResponse(){}

internal sealed class GetStudyPlans(ApplicationDbContext dbContext) : EndpointWithoutRequest<StudyPlanResponse>
{
    public override void Configure()
    {
        Get("/study-plans");
        AllowAnonymous();
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        return base.HandleAsync(ct);
    }
}