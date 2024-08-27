﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyPlanner.Data;

#nullable disable

namespace StudyPlanner.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StudyPlanner.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("StudyPlanner.Entities.ActivityCategoryEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ActivityCategories");
                });

            modelBuilder.Entity("StudyPlanner.Entities.ActivityEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ActivityCategoryEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxHours")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ActivityCategoryEntityId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("StudyPlanner.Entities.CategoryEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("StudyPlanner.Entities.ContactHoursDetailsEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ConsultationCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactHoursEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("FinalProjectExamCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LecturesCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OtherCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubGroupsCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalContactHours")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContactHoursEntityId")
                        .IsUnique();

                    b.ToTable("ContactHoursDetails");
                });

            modelBuilder.Entity("StudyPlanner.Entities.ContactHoursEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ContactHoursDetailsEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("LectureHours")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PracticeHours")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RemoteLectureHours")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RemotePracticeHours")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SelfStudyHours")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubjectEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("SubjectEntityId")
                        .IsUnique();

                    b.ToTable("ContactHours");
                });

            modelBuilder.Entity("StudyPlanner.Entities.DepartmentEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FacultyEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FacultyEntityId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("StudyPlanner.Entities.FacultyEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("StudyPlanner.Entities.NonContactHoursDetailsEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("GradingHours")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GradingNumberCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NonContactHoursEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("OtherCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NonContactHoursEntityId")
                        .IsUnique();

                    b.ToTable("NonContactHoursDetails");
                });

            modelBuilder.Entity("StudyPlanner.Entities.NonContactHoursEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NonContactHoursDetailsEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SubjectEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("SubjectEntityId")
                        .IsUnique();

                    b.ToTable("NonContactHours");
                });

            modelBuilder.Entity("StudyPlanner.Entities.StudentGroupEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DepartmentEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FacultyEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Semester")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Vf")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Vnf")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentEntityId");

                    b.HasIndex("FacultyEntityId");

                    b.ToTable("StudentGroups");
                });

            modelBuilder.Entity("StudyPlanner.Entities.StudyFormEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StudyForms");
                });

            modelBuilder.Entity("StudyPlanner.Entities.StudyPlanEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DepartmentEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentEntityId");

                    b.ToTable("StudyPlans");
                });

            modelBuilder.Entity("StudyPlanner.Entities.StudyProgramEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StudyPrograms");
                });

            modelBuilder.Entity("StudyPlanner.Entities.SubjectEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ContactHoursEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NonContactHoursEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Semester")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubjectTypeEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SubjectTypeEntityId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("StudyPlanner.Entities.SubjectTypeEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CategoryEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryEntityId");

                    b.ToTable("SubjectTypes");
                });

            modelBuilder.Entity("StudyPlanner.Entities.TeacherCardEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TeacherCards");
                });

            modelBuilder.Entity("StudyPlanner.Entities.TeacherCardSheetActivityEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ActivityEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("HoursSpent")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeacherCardSheetEntityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ActivityEntityId");

                    b.HasIndex("TeacherCardSheetEntityId");

                    b.ToTable("TeacherCardSheetActivities");
                });

            modelBuilder.Entity("StudyPlanner.Entities.TeacherCardSheetEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("SheetType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeacherCardEntityId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherCardEntityId");

                    b.ToTable("TeacherCardSheets");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StudyPlanner.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StudyPlanner.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyPlanner.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StudyPlanner.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudyPlanner.Entities.ActivityEntity", b =>
                {
                    b.HasOne("StudyPlanner.Entities.ActivityCategoryEntity", "ActivityCategoryEntity")
                        .WithMany()
                        .HasForeignKey("ActivityCategoryEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActivityCategoryEntity");
                });

            modelBuilder.Entity("StudyPlanner.Entities.ContactHoursDetailsEntity", b =>
                {
                    b.HasOne("StudyPlanner.Entities.ContactHoursEntity", "ContactHoursEntity")
                        .WithOne("ContactHoursDetailsEntity")
                        .HasForeignKey("StudyPlanner.Entities.ContactHoursDetailsEntity", "ContactHoursEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactHoursEntity");
                });

            modelBuilder.Entity("StudyPlanner.Entities.ContactHoursEntity", b =>
                {
                    b.HasOne("StudyPlanner.Entities.SubjectEntity", "SubjectEntity")
                        .WithOne("ContactHoursEntity")
                        .HasForeignKey("StudyPlanner.Entities.ContactHoursEntity", "SubjectEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubjectEntity");
                });

            modelBuilder.Entity("StudyPlanner.Entities.DepartmentEntity", b =>
                {
                    b.HasOne("StudyPlanner.Entities.FacultyEntity", "FacultyEntity")
                        .WithMany("Departments")
                        .HasForeignKey("FacultyEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FacultyEntity");
                });

            modelBuilder.Entity("StudyPlanner.Entities.NonContactHoursDetailsEntity", b =>
                {
                    b.HasOne("StudyPlanner.Entities.NonContactHoursEntity", "NonContactHoursEntity")
                        .WithOne("NonContactHoursDetailsEntity")
                        .HasForeignKey("StudyPlanner.Entities.NonContactHoursDetailsEntity", "NonContactHoursEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NonContactHoursEntity");
                });

            modelBuilder.Entity("StudyPlanner.Entities.NonContactHoursEntity", b =>
                {
                    b.HasOne("StudyPlanner.Entities.SubjectEntity", "SubjectEntity")
                        .WithOne("NonContactHoursEntity")
                        .HasForeignKey("StudyPlanner.Entities.NonContactHoursEntity", "SubjectEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubjectEntity");
                });

            modelBuilder.Entity("StudyPlanner.Entities.StudentGroupEntity", b =>
                {
                    b.HasOne("StudyPlanner.Entities.DepartmentEntity", "DepartmentEntity")
                        .WithMany("StudentGroups")
                        .HasForeignKey("DepartmentEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyPlanner.Entities.FacultyEntity", "FacultyEntity")
                        .WithMany("StudentGroups")
                        .HasForeignKey("FacultyEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartmentEntity");

                    b.Navigation("FacultyEntity");
                });

            modelBuilder.Entity("StudyPlanner.Entities.StudyPlanEntity", b =>
                {
                    b.HasOne("StudyPlanner.Entities.DepartmentEntity", "DepartmentEntity")
                        .WithMany("StudyPlans")
                        .HasForeignKey("DepartmentEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartmentEntity");
                });

            modelBuilder.Entity("StudyPlanner.Entities.SubjectEntity", b =>
                {
                    b.HasOne("StudyPlanner.Entities.SubjectTypeEntity", "SubjectTypeEntity")
                        .WithMany("Subjects")
                        .HasForeignKey("SubjectTypeEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubjectTypeEntity");
                });

            modelBuilder.Entity("StudyPlanner.Entities.SubjectTypeEntity", b =>
                {
                    b.HasOne("StudyPlanner.Entities.CategoryEntity", "CategoryEntity")
                        .WithMany("SubjectTypes")
                        .HasForeignKey("CategoryEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryEntity");
                });

            modelBuilder.Entity("StudyPlanner.Entities.TeacherCardSheetActivityEntity", b =>
                {
                    b.HasOne("StudyPlanner.Entities.ActivityEntity", "ActivityEntity")
                        .WithMany()
                        .HasForeignKey("ActivityEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyPlanner.Entities.TeacherCardSheetEntity", "TeacherCardSheetEntity")
                        .WithMany("Activities")
                        .HasForeignKey("TeacherCardSheetEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActivityEntity");

                    b.Navigation("TeacherCardSheetEntity");
                });

            modelBuilder.Entity("StudyPlanner.Entities.TeacherCardSheetEntity", b =>
                {
                    b.HasOne("StudyPlanner.Entities.TeacherCardEntity", null)
                        .WithMany("Sheets")
                        .HasForeignKey("TeacherCardEntityId");
                });

            modelBuilder.Entity("StudyPlanner.Entities.CategoryEntity", b =>
                {
                    b.Navigation("SubjectTypes");
                });

            modelBuilder.Entity("StudyPlanner.Entities.ContactHoursEntity", b =>
                {
                    b.Navigation("ContactHoursDetailsEntity")
                        .IsRequired();
                });

            modelBuilder.Entity("StudyPlanner.Entities.DepartmentEntity", b =>
                {
                    b.Navigation("StudentGroups");

                    b.Navigation("StudyPlans");
                });

            modelBuilder.Entity("StudyPlanner.Entities.FacultyEntity", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("StudentGroups");
                });

            modelBuilder.Entity("StudyPlanner.Entities.NonContactHoursEntity", b =>
                {
                    b.Navigation("NonContactHoursDetailsEntity")
                        .IsRequired();
                });

            modelBuilder.Entity("StudyPlanner.Entities.SubjectEntity", b =>
                {
                    b.Navigation("ContactHoursEntity")
                        .IsRequired();

                    b.Navigation("NonContactHoursEntity")
                        .IsRequired();
                });

            modelBuilder.Entity("StudyPlanner.Entities.SubjectTypeEntity", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("StudyPlanner.Entities.TeacherCardEntity", b =>
                {
                    b.Navigation("Sheets");
                });

            modelBuilder.Entity("StudyPlanner.Entities.TeacherCardSheetEntity", b =>
                {
                    b.Navigation("Activities");
                });
#pragma warning restore 612, 618
        }
    }
}
