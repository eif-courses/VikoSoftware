using FastEndpoints;
using StudyPlanner.Entities;
namespace StudyPlanner.Features.Admin.Category.Create;

internal sealed class Mapper : Mapper<Request, Response, CategoryEntity>
{
    public override CategoryEntity ToEntity(Request r)
    {
        return new CategoryEntity
        {
            Title = r.CategoryDto.Title,
            SubjectTypes = r.CategoryDto.SubjectTypes.Select(st => new SubjectTypeEntity
            {
                Name = st.Name,
                Subjects = st.Subjects.Select(s => new SubjectEntity
                {
                    Title = s.Title,
                    Credits = s.Credits,
                    Semester = s.Semester
                }).ToList()
            }).ToList()
        };
    }
}