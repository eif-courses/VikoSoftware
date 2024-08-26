using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class CategoryEntity
{
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }  = Ulid.NewUlid();
    public string Title { get; set; }
    public ICollection<SubjectTypeEntity> SubjectTypes { get; set; } = new List<SubjectTypeEntity>();
}
