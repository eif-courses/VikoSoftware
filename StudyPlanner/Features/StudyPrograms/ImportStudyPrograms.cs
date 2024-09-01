using OfficeOpenXml;
using StudyPlanner.Data;
using StudyPlanner.Features.Admin.Categories;

namespace StudyPlanner.Features.StudyPrograms;

using FastEndpoints;

// internal sealed record CreateCategoryRequest(CategoryDto CategoryDto);
// internal sealed record CreateCategoryResponse(string Message);
internal sealed class ImportStudyPrograms(ApplicationDbContext dbContext) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("study-programs/import");
        AllowFileUploads();
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        // Check if a file was uploaded
        if (Files.Count == 0)
        {
            await SendErrorsAsync(400, ct);
            return;
        }

        var file = Files[0]; // Get the first uploaded file

        using var stream = new MemoryStream();
        await file.CopyToAsync(stream, ct);
        stream.Position = 0;

        using var package = new ExcelPackage(stream);
        var worksheet = package.Workbook.Worksheets[0]; // Assuming the first worksheet

        ///var subjects = new List<Subject>();
        for (int row = 6; row <= worksheet.Dimension.End.Row; row++) // Start from row 2 assuming row 1 is header
        {
            // var subject = new Subject
            // {
            //     SubjectName = worksheet.Cells[row, 1].Text,
            //     Code = worksheet.Cells[row, 2].Text,
            //     PP = int.Parse(worksheet.Cells[row, 3].Text),
            //     Value1 = int.Parse(worksheet.Cells[row, 4].Text),
            //     Value2 = int.Parse(worksheet.Cells[row, 5].Text),
            //     OtherCode = worksheet.Cells[row, 6].Text,
            //     Category = worksheet.Cells[row, 7].Text,
            //     SubCategory = worksheet.Cells[row, 8].Text,
            //     Type = worksheet.Cells[row, 9].Text
            // };
            // subjects.Add(subject);
        }

        // Here you can save the subjects list to the database or perform further processing

       // await SendOkAsync(subjects, ct);
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