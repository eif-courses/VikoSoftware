using FastEndpoints;

namespace StudyPlanner.Features.Faculty.Create;

internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("/faculty/create");
        AllowAnonymous();
    }
}
