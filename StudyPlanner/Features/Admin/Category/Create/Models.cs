using StudyPlanner.Dto;

namespace StudyPlanner.Features.Admin.Category.Create;

internal sealed record Request(CategoryDto CategoryDto);
internal sealed record Response(string Message);