namespace StudyPlanner.Shared.Entities;

public class Category : BaseEntity
{
    public string Title { get; set; }
    public ICollection<SubjectType> SubjectTypes { get; set; } = new List<SubjectType>();
}