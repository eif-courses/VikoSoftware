namespace StudyPlanner.Entities;

public class TeacherCardSheetActivityEntity : BaseEntity
{
    private int _hoursSpent;

    public Ulid TeacherCardSheetEntityId { get; set; }
    public TeacherCardSheetEntity TeacherCardSheetEntity { get; set; }
    public Ulid ActivityEntityId { get; set; }
    public ActivityEntity ActivityEntity { get; set; }

    public int HoursSpent
    {
        get => _hoursSpent;
        set
        {
            if (value > ActivityEntity.MaxHours)
            {
                throw new ArgumentException($"Hours spent ({value}) cannot exceed max allowed hours ({ActivityEntity.MaxHours}) for activity {ActivityEntity.Title}.");
            }
            _hoursSpent = value;
        }
    }
}