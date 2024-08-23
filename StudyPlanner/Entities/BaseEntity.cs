
namespace StudyPlanner.Entities;

public abstract class BaseEntity
{
    public Ulid Id { get; set; } = Ulid.NewUlid();
}