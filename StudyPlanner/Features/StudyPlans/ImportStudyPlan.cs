using OfficeOpenXml;
using StudyPlanner.Data;


namespace StudyPlanner.Features.StudyPlans;


using FastEndpoints;

 internal sealed record StudyPlanExcelFileRequest(IFormFile file);
// internal sealed record CreateCategoryResponse(string Message);
internal sealed class ImportStudyPlan(ApplicationDbContext dbContext) : Endpoint<StudyPlanExcelFileRequest>
{
    public override void Configure()
    {
        Post("study-plans/import");
        AllowFileUploads();
        AllowAnonymous();
    }

    public override async Task HandleAsync(StudyPlanExcelFileRequest r, CancellationToken ct)
    {
        // Check if the file is present and not empty
        if (r.file == null || r.file.Length == 0)
        {
            await SendErrorsAsync(400, ct);
            return;
        }

        using var stream = new MemoryStream();
        await r.file.CopyToAsync(stream, ct);
        stream.Position = 0;

        using var package = new ExcelPackage(stream);
        var worksheet = package.Workbook.Worksheets[0]; // Assuming the first worksheet

        var subjects = new List<string>();
        for (int row = 7; row <= worksheet.Dimension.End.Row; row++) // Start from row 7, as you intended
        {
            subjects.Add(worksheet.Cells[row, 4].Value?.ToString());
        }

        // Returning the list of subjects as a response
        await SendOkAsync(subjects, ct);
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

