namespace StudyPlanner.Entities;

public class ActivityEntity : BaseEntity
{
    public string Identifier { get; set; }
    public string Title { get; set; }
    public int MaxHours { get; set; }
    public string Comments { get; set; }
    
    public Ulid ActivityCategoryEntityId { get; set; }
    public ActivityCategoryEntity ActivityCategoryEntity { get; set; }
}