namespace StudyPlanner.Entities;

public class FacultyEntity : BaseEntity
{
    public string Name { get; set; }
    public ICollection<DepartmentEntity> Departments { get; set; } = new List<DepartmentEntity>();
    public ICollection<StudentGroupEntity> StudentGroups { get; set; } = new List<StudentGroupEntity>();
}