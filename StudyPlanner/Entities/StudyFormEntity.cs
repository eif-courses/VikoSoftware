using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class StudyFormEntity
{
    
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }
    public string Name { get; set; }
}
