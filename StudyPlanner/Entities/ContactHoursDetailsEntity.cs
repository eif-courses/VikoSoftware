using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class ContactHoursDetailsEntity 
{
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }
    public int SubGroupsCount { get; set; }
    public int LecturesCount { get; set; }
    public int FinalProjectExamCount { get; set; }
    public int OtherCount { get; set; }
    public int ConsultationCount { get; set; }
    public int TotalContactHours { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public Ulid ContactHoursEntityId { get; set; }
    public ContactHoursEntity ContactHoursEntity { get; set; }
}