using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class StudyPlanEntity
{
    
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public Ulid DepartmentEntityId { get; set; }
    public DepartmentEntity DepartmentEntity { get; set; }
}