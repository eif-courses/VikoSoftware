using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class TeacherCardSheetActivityEntity
{
    
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }  = Ulid.NewUlid();
    private int _hoursSpent;

    [Column(TypeName = "varchar(255)")]
    public Ulid TeacherCardSheetEntityId { get; set; }
    public TeacherCardSheetEntity TeacherCardSheetEntity { get; set; }
    [Column(TypeName = "varchar(255)")]
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