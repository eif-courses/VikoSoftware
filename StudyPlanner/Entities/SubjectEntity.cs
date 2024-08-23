namespace StudyPlanner.Entities; 
public class SubjectEntity : BaseEntity
{
    public string Title { get; set; }
    public int Credits { get; set; }
    public int Semester { get; set; }
    
    public Ulid ContactHoursEntityId { get; set; }
    public ContactHoursEntity ContactHoursEntity { get; set; }
    
    public Ulid NonContactHoursEntityId { get; set; }
    public NonContactHoursEntity NonContactHoursEntity { get; set; }
    
    public Ulid SubjectTypeEntityId { get; set; }
    public SubjectTypeEntity SubjectTypeEntity { get; set; }
}







