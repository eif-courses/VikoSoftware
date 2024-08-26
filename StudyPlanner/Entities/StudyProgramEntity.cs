using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class StudyProgramEntity
{
    
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }  = Ulid.NewUlid();
    public string Name { get; set; }
}