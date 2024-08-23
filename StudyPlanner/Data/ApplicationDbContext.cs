using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudyPlanner.Shared.Entities;

namespace StudyPlanner.Shared.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public static readonly string ApplicationDatabase = nameof(ApplicationDatabase).ToLower();
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<SubjectType> SubjectTypes { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<StudyPlan> StudyPlans { get; set; }
    public DbSet<StudyProgram> StudyPrograms { get; set; }
    public DbSet<StudyForm> StudyForms { get; set; }
    public DbSet<StudentGroup> StudentGroups { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<ContactHours> ContactHours { get; set; }
    public DbSet<NonContactHours> NonContactHours { get; set; }
    public DbSet<ContactHoursDetails> ContactHoursDetails { get; set; }
    public DbSet<NonContactHoursDetails> NonContactHoursDetails { get; set; }
    public DbSet<TeacherCardSheetActivity> TeacherCardSheetActivities { get; set; }
    public DbSet<TeacherCardSheet> TeacherCardSheets { get; set; }
    public DbSet<TeacherCard> TeacherCards { get; set; }
    public DbSet<ActivityCategory> ActivityCategories { get; set; }
    public DbSet<Activity> Activities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<BaseEntity>()
            .Property(e => e.Id)
            .HasConversion(
                v => v.ToString(),
                v => Ulid.Parse(v.ToString()));


        modelBuilder.Entity<SubjectType>()
            .HasOne(st => st.Category)
            .WithMany(c => c.SubjectTypes)
            .HasForeignKey(st => st.Id);

        modelBuilder.Entity<Department>()
            .HasOne(d => d.Faculty)
            .WithMany(f => f.Departments)
            .HasForeignKey(d => d.Id);

        modelBuilder.Entity<StudentGroup>()
            .HasOne(sg => sg.Department)
            .WithMany(d => d.StudentGroups)
            .HasForeignKey(sg => sg.Id);

        modelBuilder.Entity<StudentGroup>()
            .HasOne(sg => sg.Faculty)
            .WithMany(f => f.StudentGroups)
            .HasForeignKey(sg => sg.Id);

        modelBuilder.Entity<Subject>()
            .HasOne(s => s.SubjectType)
            .WithMany(st => st.Subjects)
            .HasForeignKey(s => s.Id);

        modelBuilder.Entity<ContactHours>()
            .HasOne(ch => ch.Subject)
            .WithOne(s => s.ContactHours)
            .HasForeignKey<ContactHours>(ch => ch.Id);

        modelBuilder.Entity<NonContactHours>()
            .HasOne(nch => nch.Subject)
            .WithOne(s => s.NonContactHours)
            .HasForeignKey<NonContactHours>(nch => nch.Id);

        modelBuilder.Entity<ContactHoursDetails>()
            .HasOne(chd => chd.ContactHours)
            .WithOne(ch => ch.ContactHoursDetails)
            .HasForeignKey<ContactHoursDetails>(chd => chd.Id);

        modelBuilder.Entity<NonContactHoursDetails>()
            .HasOne(nchd => nchd.NonContactHours)
            .WithOne(nch => nch.NonContactHoursDetails)
            .HasForeignKey<NonContactHoursDetails>(nchd => nchd.Id);

        modelBuilder.Entity<TeacherCardSheetActivity>()
            .HasOne(tcsa => tcsa.Activity)
            .WithMany()
            .HasForeignKey(tcsa => tcsa.Id);

        modelBuilder.Entity<TeacherCardSheetActivity>()
            .HasOne(tcsa => tcsa.Sheet)
            .WithMany(tcs => tcs.Activities)
            .HasForeignKey(tcsa => tcsa.Id);

        modelBuilder.Entity<Activity>()
            .HasOne(a => a.Category)
            .WithMany()
            .HasForeignKey(a => a.Id);
    }
}