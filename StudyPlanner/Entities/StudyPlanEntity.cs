namespace StudyPlanner.Entities;

public class StudyPlanEntity : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DepartmentEntity DepartmentEntity { get; set; } = null!;
}