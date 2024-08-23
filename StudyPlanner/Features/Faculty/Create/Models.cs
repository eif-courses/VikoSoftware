namespace StudyPlanner.Features.Faculty.Create;

using StudyPlanner.Entities;
internal sealed record Request(FacultyEntity CategoryDto);
internal sealed record Response(string Message);