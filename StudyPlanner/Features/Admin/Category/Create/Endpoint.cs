using FastEndpoints;
using StudyPlanner.Data;

namespace StudyPlanner.Features.Admin.Category.Create;
internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
{
    private readonly ApplicationDbContext _dbContext;
    
    public Endpoint(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override void Configure()
    {
        Post("/admin/category/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var categoryEntity = Map.ToEntity(r);
        
        _dbContext.Categories.Add(categoryEntity);
        await _dbContext.SaveChangesAsync(c);

        var response = new Response($"Kategorija {categoryEntity.Title} sėkmingai sukurtas!");
        
        await SendAsync(response,200, c);
    }
}


// internal sealed class Validator : Validator<Request>
// {
//     public Validator()
//     {
//         RuleFor(x => x.Title)
//             .NotEmpty()
//             .WithMessage("Title cannot be empty!");
//
//         RuleFor(x => x.Description)
//             .NotEmpty()
//             .WithMessage("Description cannot be empty!");
//     }
// }