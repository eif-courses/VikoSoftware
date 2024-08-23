namespace StudyPlanner.Entities;

public enum TeacherCardSheetTypes
{
    FULLTIME = 0,
    HALFTIME = 1,
    OVERTIME = 2
}

public class TeacherCardSheetEntity : BaseEntity
{
    public TeacherCardSheetTypes SheetType { get; set; }

    public ICollection<TeacherCardSheetActivityEntity> Activities { get; set; } =
        new List<TeacherCardSheetActivityEntity>();
}