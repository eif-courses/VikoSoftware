namespace StudyPlanner.Entities;

public class TeacherCardEntity : BaseEntity
{
    public string Title { get; set; }
    public int Year { get; set; }
    public ICollection<TeacherCardSheetEntity> Sheets { get; set; } = new List<TeacherCardSheetEntity>();
}