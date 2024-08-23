using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class TeacherCardEntity
{
    
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public ICollection<TeacherCardSheetEntity> Sheets { get; set; } = new List<TeacherCardSheetEntity>();
}