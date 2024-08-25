using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyPlanner.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyForms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyPrograms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCards",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Identifier = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    MaxHours = table.Column<int>(type: "INTEGER", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: false),
                    ActivityCategoryEntityId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityCategories_ActivityCategoryEntityId",
                        column: x => x.ActivityCategoryEntityId,
                        principalTable: "ActivityCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryEntityId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectTypes_Categories_CategoryEntityId",
                        column: x => x.CategoryEntityId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FacultyEntityId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyEntityId",
                        column: x => x.FacultyEntityId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCardSheets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    SheetType = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherCardEntityId = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCardSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherCardSheets_TeacherCards_TeacherCardEntityId",
                        column: x => x.TeacherCardEntityId,
                        principalTable: "TeacherCards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Credits = table.Column<int>(type: "INTEGER", nullable: false),
                    Semester = table.Column<int>(type: "INTEGER", nullable: false),
                    ContactHoursEntityId = table.Column<string>(type: "varchar(255)", nullable: false),
                    NonContactHoursEntityId = table.Column<string>(type: "varchar(255)", nullable: false),
                    SubjectTypeEntityId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_SubjectTypes_SubjectTypeEntityId",
                        column: x => x.SubjectTypeEntityId,
                        principalTable: "SubjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentGroups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Semester = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Vf = table.Column<int>(type: "INTEGER", nullable: false),
                    Vnf = table.Column<int>(type: "INTEGER", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartmentEntityId = table.Column<string>(type: "varchar(255)", nullable: false),
                    FacultyEntityId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentGroups_Departments_DepartmentEntityId",
                        column: x => x.DepartmentEntityId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGroups_Faculties_FacultyEntityId",
                        column: x => x.FacultyEntityId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyPlans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentEntityId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyPlans_Departments_DepartmentEntityId",
                        column: x => x.DepartmentEntityId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCardSheetActivities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    TeacherCardSheetEntityId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ActivityEntityId = table.Column<string>(type: "varchar(255)", nullable: false),
                    HoursSpent = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCardSheetActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherCardSheetActivities_Activities_ActivityEntityId",
                        column: x => x.ActivityEntityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCardSheetActivities_TeacherCardSheets_TeacherCardSheetEntityId",
                        column: x => x.TeacherCardSheetEntityId,
                        principalTable: "TeacherCardSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactHours",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    LectureHours = table.Column<int>(type: "INTEGER", nullable: false),
                    PracticeHours = table.Column<int>(type: "INTEGER", nullable: false),
                    RemoteLectureHours = table.Column<int>(type: "INTEGER", nullable: true),
                    RemotePracticeHours = table.Column<int>(type: "INTEGER", nullable: true),
                    SelfStudyHours = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    ContactHoursDetailsEntityId = table.Column<string>(type: "varchar(255)", nullable: false),
                    SubjectEntityId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactHours_Subjects_SubjectEntityId",
                        column: x => x.SubjectEntityId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NonContactHours",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    NonContactHoursDetailsEntityId = table.Column<string>(type: "varchar(255)", nullable: false),
                    SubjectEntityId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonContactHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NonContactHours_Subjects_SubjectEntityId",
                        column: x => x.SubjectEntityId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactHoursDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    SubGroupsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    LecturesCount = table.Column<int>(type: "INTEGER", nullable: false),
                    FinalProjectExamCount = table.Column<int>(type: "INTEGER", nullable: false),
                    OtherCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ConsultationCount = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalContactHours = table.Column<int>(type: "INTEGER", nullable: false),
                    ContactHoursEntityId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactHoursDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactHoursDetails_ContactHours_ContactHoursEntityId",
                        column: x => x.ContactHoursEntityId,
                        principalTable: "ContactHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NonContactHoursDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    GradingNumberCount = table.Column<int>(type: "INTEGER", nullable: false),
                    GradingHours = table.Column<int>(type: "INTEGER", nullable: false),
                    OtherCount = table.Column<int>(type: "INTEGER", nullable: false),
                    NonContactHoursEntityId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonContactHoursDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NonContactHoursDetails_NonContactHours_NonContactHoursEntityId",
                        column: x => x.NonContactHoursEntityId,
                        principalTable: "NonContactHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityCategoryEntityId",
                table: "Activities",
                column: "ActivityCategoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactHours_SubjectEntityId",
                table: "ContactHours",
                column: "SubjectEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactHoursDetails_ContactHoursEntityId",
                table: "ContactHoursDetails",
                column: "ContactHoursEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyEntityId",
                table: "Departments",
                column: "FacultyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_NonContactHours_SubjectEntityId",
                table: "NonContactHours",
                column: "SubjectEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NonContactHoursDetails_NonContactHoursEntityId",
                table: "NonContactHoursDetails",
                column: "NonContactHoursEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroups_DepartmentEntityId",
                table: "StudentGroups",
                column: "DepartmentEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroups_FacultyEntityId",
                table: "StudentGroups",
                column: "FacultyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlans_DepartmentEntityId",
                table: "StudyPlans",
                column: "DepartmentEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectTypeEntityId",
                table: "Subjects",
                column: "SubjectTypeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTypes_CategoryEntityId",
                table: "SubjectTypes",
                column: "CategoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCardSheetActivities_ActivityEntityId",
                table: "TeacherCardSheetActivities",
                column: "ActivityEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCardSheetActivities_TeacherCardSheetEntityId",
                table: "TeacherCardSheetActivities",
                column: "TeacherCardSheetEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCardSheets_TeacherCardEntityId",
                table: "TeacherCardSheets",
                column: "TeacherCardEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactHoursDetails");

            migrationBuilder.DropTable(
                name: "NonContactHoursDetails");

            migrationBuilder.DropTable(
                name: "StudentGroups");

            migrationBuilder.DropTable(
                name: "StudyForms");

            migrationBuilder.DropTable(
                name: "StudyPlans");

            migrationBuilder.DropTable(
                name: "StudyPrograms");

            migrationBuilder.DropTable(
                name: "TeacherCardSheetActivities");

            migrationBuilder.DropTable(
                name: "ContactHours");

            migrationBuilder.DropTable(
                name: "NonContactHours");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "TeacherCardSheets");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "ActivityCategories");

            migrationBuilder.DropTable(
                name: "TeacherCards");

            migrationBuilder.DropTable(
                name: "SubjectTypes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
