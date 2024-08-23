namespace StudyPlanner.Entities;

public class StudentGroupEntity : BaseEntity
{
    public string Name { get; set; }
    public int Semester { get; set; }
    public int StudentNumber { get; set; }
    public int Vf { get; set; }
    public int Vnf { get; set; }
    public int Year { get; set; }
    public Ulid DepartmentEntityId { get; set; }
    public DepartmentEntity DepartmentEntity { get; set; }
    public Ulid FacultyEntityId { get; set; }
    public FacultyEntity FacultyEntity { get; set; }
}