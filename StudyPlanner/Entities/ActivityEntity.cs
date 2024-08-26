using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class ActivityEntity
{
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; } = Ulid.NewUlid();
    
    public string Identifier { get; set; }
    public string Title { get; set; }
    public int MaxHours { get; set; }
    public string Comments { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public Ulid ActivityCategoryEntityId { get; set; }
    public ActivityCategoryEntity ActivityCategoryEntity { get; set; }
}