namespace StudyPlanner.Entities;

public class SubjectTypeEntity : BaseEntity
{
    public string Name { get; set; }
    public ICollection<SubjectEntity> Subjects { get; set; } = new List<SubjectEntity>();
    public Ulid CategoryEntityId { get; set; }
    public CategoryEntity CategoryEntity { get; set; }
    
}