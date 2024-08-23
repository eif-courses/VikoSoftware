namespace StudyPlanner.Entities;

public class NonContactHoursEntity : BaseEntity
{
    
    public Ulid NonContactHoursDetailsEntityId { get; set; }
    public NonContactHoursDetailsEntity NonContactHoursDetailsEntity { get; set; }
    public Ulid SubjectEntityId { get; set; }
    public SubjectEntity SubjectEntity { get; set; }
}