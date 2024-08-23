namespace StudyPlanner.Dto;

public class SubjectTypeDto
{
    public string Name { get; set; }
    public List<SubjectDto> Subjects { get; set; } = new List<SubjectDto>();
}