namespace StudyPlanner.Entities;

public class NonContactHoursDetailsEntity : BaseEntity
{
    public int GradingNumberCount { get; set; }
    public int GradingHours { get; set; }
    public int OtherCount { get; set; }
    
    public Ulid NonContactHoursEntityId { get; set; }
    public NonContactHoursEntity NonContactHoursEntity { get; set; }
}