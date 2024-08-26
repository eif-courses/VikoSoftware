using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class FacultyEntity
{
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }  = Ulid.NewUlid();
    public string Name { get; set; }
    public ICollection<DepartmentEntity> Departments { get; set; } = new List<DepartmentEntity>();
    public ICollection<StudentGroupEntity> StudentGroups { get; set; } = new List<StudentGroupEntity>();
}