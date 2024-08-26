using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class DepartmentEntity
{
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }  = Ulid.NewUlid();
    public string Name { get; set; }
   
    public ICollection<StudyPlanEntity> StudyPlans { get; set; } = new List<StudyPlanEntity>();
    public ICollection<StudentGroupEntity> StudentGroups { get; set; } = new List<StudentGroupEntity>();
    [Column(TypeName = "varchar(255)")]
    public Ulid FacultyEntityId { get; set; }
    public FacultyEntity FacultyEntity { get; set; }
}