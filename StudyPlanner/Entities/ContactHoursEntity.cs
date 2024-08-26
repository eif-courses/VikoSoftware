using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class ContactHoursEntity 
{
    
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }  = Ulid.NewUlid();
    public int LectureHours { get; set; }
    public int PracticeHours { get; set; }
    public int? RemoteLectureHours { get; set; }
    public int? RemotePracticeHours { get; set; }
    public int SelfStudyHours { get; set; }
    public string Notes { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public Ulid ContactHoursDetailsEntityId { get; set; }
    public ContactHoursDetailsEntity ContactHoursDetailsEntity { get; set; }
    [Column(TypeName = "varchar(255)")]
    public Ulid SubjectEntityId { get; set; }
    public SubjectEntity SubjectEntity { get; set; }
}