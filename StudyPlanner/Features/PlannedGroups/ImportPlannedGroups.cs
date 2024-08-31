using StudyPlanner.Data;
using StudyPlanner.Dto;
using StudyPlanner.Features.Admin.Categories;

namespace StudyPlanner.Features.StudyPlans;


using FastEndpoints;

// internal sealed record CreateCategoryRequest(CategoryDto CategoryDto);
// internal sealed record CreateCategoryResponse(string Message);
internal sealed class ImportPlannedGroups(ApplicationDbContext dbContext) : Endpoint<CreateCategoryRequest, CreateCategoryResponse>
{
    public override void Configure()
    {
        Post("/study-programs/import");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateCategoryRequest r, CancellationToken c)
    {
        //var category = Map.ToEntity(r);
        
        // dbContext.Categories.Add(category);
        // await dbContext.SaveChangesAsync(c);
        //
        // var response = new CreateCategoryResponse($"Kategorija {category.Title} sėkmingai sukurtas!");
        //
        // await SendAsync(response,200, c);
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


// internal sealed class CreateCategoryMapper : Mapper<CreateCategoryRequest, CreateCategoryResponse, CategoryEntity>
// {
//     public override CategoryEntity ToEntity(CreateCategoryRequest r)
//     {
//         return new CategoryEntity
//         {
//             Title = r.CategoryDto.Title,
//             SubjectTypes = r.CategoryDto.SubjectTypes.Select(st => new SubjectTypeEntity
//             {
//                 Name = st.Name,
//                 Subjects = st.Subjects.Select(s => new SubjectEntity
//                 {
//                     Title = s.Title,
//                     Credits = s.Credits,
//                     Semester = s.Semester
//                 }).ToList()
//             }).ToList()
//         };
//     }
// }

