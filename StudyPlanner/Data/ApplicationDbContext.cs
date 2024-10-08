﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Namotion.Reflection;
using StudyPlanner.Entities;

namespace StudyPlanner.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }


    public static readonly string ApplicationDatabase = nameof(ApplicationDatabase).ToLower();

    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<SubjectTypeEntity> SubjectTypes { get; set; }
    public DbSet<FacultyEntity> Faculties { get; set; }
    public DbSet<DepartmentEntity> Departments { get; set; }
    public DbSet<StudyPlanEntity> StudyPlans { get; set; }
    public DbSet<StudyProgramEntity> StudyPrograms { get; set; }
    public DbSet<StudyFormEntity> StudyForms { get; set; }
    public DbSet<StudentGroupEntity> StudentGroups { get; set; }
    public DbSet<SubjectEntity> Subjects { get; set; }
    public DbSet<ContactHoursEntity> ContactHours { get; set; }
    public DbSet<NonContactHoursEntity> NonContactHours { get; set; }
    public DbSet<ContactHoursDetailsEntity> ContactHoursDetails { get; set; }
    public DbSet<NonContactHoursDetailsEntity> NonContactHoursDetails { get; set; }
    public DbSet<TeacherCardSheetActivityEntity> TeacherCardSheetActivities { get; set; }
    public DbSet<TeacherCardSheetEntity> TeacherCardSheets { get; set; }
    public DbSet<TeacherCardEntity> TeacherCards { get; set; }
    public DbSet<ActivityCategoryEntity> ActivityCategories { get; set; }
    public DbSet<ActivityEntity> Activities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2", Name = "Deputy", NormalizedName = "DEPUTY" },
            new IdentityRole { Id = "3", Name = "Lecturer", NormalizedName = "LECTURER" },
            new IdentityRole { Id = "4", Name = "Faculty", NormalizedName = "FACULTY" },
            new IdentityRole { Id = "5", Name = "Department", NormalizedName = "DEPARTMENT" }
        );
        
        var ulidConverter = new UlidValueConverter();

        // Apply Ulid conversion globally
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            var properties = entity.ClrType.GetProperties()
                .Where(p => p.PropertyType == typeof(Ulid));
            foreach (var property in properties)
            {
                modelBuilder.Entity(entity.ClrType)
                    .Property(property.Name)
                    .HasConversion(ulidConverter);
            }
        }


        modelBuilder.Entity<SubjectTypeEntity>()
            .HasOne(st => st.CategoryEntity)
            .WithMany(c => c.SubjectTypes)
            .HasForeignKey(st => st.CategoryEntityId);

        modelBuilder.Entity<DepartmentEntity>()
            .HasOne(d => d.FacultyEntity)
            .WithMany(f => f.Departments)
            .HasForeignKey(d => d.FacultyEntityId);

        modelBuilder.Entity<StudentGroupEntity>()
            .HasOne(sg => sg.DepartmentEntity)
            .WithMany(d => d.StudentGroups)
            .HasForeignKey(sg => sg.DepartmentEntityId);

        modelBuilder.Entity<StudentGroupEntity>()
            .HasOne(sg => sg.FacultyEntity)
            .WithMany(f => f.StudentGroups)
            .HasForeignKey(sg => sg.FacultyEntityId);

        modelBuilder.Entity<SubjectEntity>()
            .HasOne(s => s.SubjectTypeEntity)
            .WithMany(st => st.Subjects)
            .HasForeignKey(s => s.SubjectTypeEntityId);

        modelBuilder.Entity<ContactHoursEntity>()
            .HasOne(ch => ch.SubjectEntity)
            .WithOne(s => s.ContactHoursEntity)
            .HasForeignKey<ContactHoursEntity>(ch => ch.SubjectEntityId);

        modelBuilder.Entity<NonContactHoursEntity>()
            .HasOne(nch => nch.SubjectEntity)
            .WithOne(s => s.NonContactHoursEntity)
            .HasForeignKey<NonContactHoursEntity>(nch => nch.SubjectEntityId);

        modelBuilder.Entity<ContactHoursDetailsEntity>()
            .HasOne(chd => chd.ContactHoursEntity)
            .WithOne(ch => ch.ContactHoursDetailsEntity)
            .HasForeignKey<ContactHoursDetailsEntity>(chd => chd.ContactHoursEntityId);

        modelBuilder.Entity<NonContactHoursDetailsEntity>()
            .HasOne(nchd => nchd.NonContactHoursEntity)
            .WithOne(nch => nch.NonContactHoursDetailsEntity)
            .HasForeignKey<NonContactHoursDetailsEntity>(nchd => nchd.NonContactHoursEntityId);

        modelBuilder.Entity<TeacherCardSheetActivityEntity>()
            .HasOne(tcsa => tcsa.ActivityEntity)
            .WithMany()
            .HasForeignKey(tcsa => tcsa.ActivityEntityId);

        modelBuilder.Entity<TeacherCardSheetActivityEntity>()
            .HasOne(tcsa => tcsa.TeacherCardSheetEntity)
            .WithMany(tcs => tcs.Activities)
            .HasForeignKey(tcsa => tcsa.TeacherCardSheetEntityId);

        modelBuilder.Entity<ActivityEntity>()
            .HasOne(a => a.ActivityCategoryEntity)
            .WithMany()
            .HasForeignKey(a => a.ActivityCategoryEntityId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite($"Data Source={ApplicationDatabase}.db");
        }
    }
}