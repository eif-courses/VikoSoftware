namespace StudyPlanner.Dto;

public class CategoryDto
{
    public string Title { get; set; }
    public List<SubjectTypeDto> SubjectTypes { get; set; } = new List<SubjectTypeDto>();
}