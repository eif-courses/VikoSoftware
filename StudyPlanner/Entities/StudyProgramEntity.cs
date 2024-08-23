using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class StudyProgramEntity
{
    
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }
    public string Name { get; set; }
}