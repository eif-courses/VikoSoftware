using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class ActivityCategoryEntity
{
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }
    public string Title { get; set; } = string.Empty;
}
