namespace StudyPlanner.Entities;

public class ContactHoursEntity : BaseEntity
{
    public int LectureHours { get; set; }
    public int PracticeHours { get; set; }
    public int? RemoteLectureHours { get; set; }
    public int? RemotePracticeHours { get; set; }
    public int SelfStudyHours { get; set; }
    public string Notes { get; set; }
    
    public Ulid ContactHoursDetailsEntityId { get; set; }
    public ContactHoursDetailsEntity ContactHoursDetailsEntity { get; set; }
    public Ulid SubjectEntityId { get; set; }
    public SubjectEntity SubjectEntity { get; set; }
}