using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPlanner.Entities;

public class StudentGroupEntity
{
    
    [Column(TypeName = "varchar(255)")]
    public Ulid Id { get; set; }  = Ulid.NewUlid();
    public string Name { get; set; }
    public int Semester { get; set; }
    public int StudentNumber { get; set; }
    public int Vf { get; set; }
    public int Vnf { get; set; }
    public int Year { get; set; }
    [Column(TypeName = "varchar(255)")]
    public Ulid DepartmentEntityId { get; set; }
    public DepartmentEntity DepartmentEntity { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public Ulid FacultyEntityId { get; set; }
    public FacultyEntity FacultyEntity { get; set; }
}