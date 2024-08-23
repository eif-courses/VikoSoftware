namespace StudyPlanner.Entities;

public class DepartmentEntity : BaseEntity
{
    public string Name { get; set; }
   
    public ICollection<StudyPlanEntity> StudyPlans { get; set; } = new List<StudyPlanEntity>();
    public ICollection<StudentGroupEntity> StudentGroups { get; set; } = new List<StudentGroupEntity>();
    
    public Ulid FacultyEntityId { get; set; }
    public FacultyEntity FacultyEntity { get; set; }
}