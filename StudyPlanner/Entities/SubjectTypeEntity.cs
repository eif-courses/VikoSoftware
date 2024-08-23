using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class SubjectTypeEntity
{
    
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }
    public string Name { get; set; }
    public ICollection<SubjectEntity> Subjects { get; set; } = new List<SubjectEntity>();
    [Column(TypeName = "varchar(255)")]
    public Ulid CategoryEntityId { get; set; }
    public CategoryEntity CategoryEntity { get; set; }
    
}