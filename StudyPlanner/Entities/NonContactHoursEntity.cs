using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class NonContactHoursEntity
{
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }  = Ulid.NewUlid();
    
    [Column(TypeName = "varchar(255)")]
    public Ulid NonContactHoursDetailsEntityId { get; set; }
    public NonContactHoursDetailsEntity NonContactHoursDetailsEntity { get; set; }
    [Column(TypeName = "varchar(255)")]
    public Ulid SubjectEntityId { get; set; }
    public SubjectEntity SubjectEntity { get; set; }
}