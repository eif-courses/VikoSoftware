using FastEndpoints;

namespace StudyPlanner.Features.Faculty.Create;

internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("/faculty/create");
        AllowAnonymous();
    }
    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        // var categoryEntity = Map.ToEntity(r);
        //
        // _dbContext.Categories.Add(categoryEntity);
        // await _dbContext.SaveChangesAsync(c);
        //
        // var response = new Response($"Kategorija {categoryEntity.Title} sėkmingai sukurtas!");
        //
       // await SendAsync(response,200, c);
    }
}
