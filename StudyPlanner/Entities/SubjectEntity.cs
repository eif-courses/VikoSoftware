using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities; 
public class SubjectEntity
{
    
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }  = Ulid.NewUlid();
    public string Title { get; set; }
    public int Credits { get; set; }
    public int Semester { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public Ulid ContactHoursEntityId { get; set; }
    public ContactHoursEntity ContactHoursEntity { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public Ulid NonContactHoursEntityId { get; set; }
    public NonContactHoursEntity NonContactHoursEntity { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public Ulid SubjectTypeEntityId { get; set; }
    public SubjectTypeEntity SubjectTypeEntity { get; set; }
}







