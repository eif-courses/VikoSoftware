namespace StudyPlanner.Entities;

public class CategoryEntity : BaseEntity
{
    public string Title { get; set; }
    public ICollection<SubjectTypeEntity> SubjectTypes { get; set; } = new List<SubjectTypeEntity>();
}
