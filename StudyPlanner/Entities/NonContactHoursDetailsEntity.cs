using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class NonContactHoursDetailsEntity
{
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }  = Ulid.NewUlid();
    public int GradingNumberCount { get; set; }
    public int GradingHours { get; set; }
    public int OtherCount { get; set; }
    [Column(TypeName = "varchar(255)")]
    public Ulid NonContactHoursEntityId { get; set; }
    public NonContactHoursEntity NonContactHoursEntity { get; set; }
}