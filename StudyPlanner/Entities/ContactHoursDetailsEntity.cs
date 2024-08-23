namespace StudyPlanner.Entities;

public class ContactHoursDetailsEntity : BaseEntity
{
    public int SubGroupsCount { get; set; }
    public int LecturesCount { get; set; }
    public int FinalProjectExamCount { get; set; }
    public int OtherCount { get; set; }
    public int ConsultationCount { get; set; }
    public int TotalContactHours { get; set; }
    
    public Ulid ContactHoursEntityId { get; set; }
    public ContactHoursEntity ContactHoursEntity { get; set; }
}