using Microsoft.EntityFrameworkCore.Migrations;

namespace SCM.StudentCourses.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    CourseNo = table.Column<string>(maxLength: 10, nullable: true),
                    CreditHours = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    ObtainedCreditHours = table.Column<float>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseNo", "CreditHours", "Name" },
                values: new object[,]
                {
                    { 1, "BSCS-301", 3f, "Introduction to Computer Science - I" },
                    { 2, "BSCS-303", 4f, "Mathematics - I (Calculus)" },
                    { 3, "BSCS-305", 3f, "Statistics and Data Analysis" },
                    { 4, "BSCS-307", 3f, "Physics - I (General Physics)" },
                    { 5, "BSCS-309", 3f, "English" },
                    { 6, "BSCS-311", 3f, "Islamic Learning & Pakistan Studies" }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CourseId", "IsDeleted", "ObtainedCreditHours", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, false, 3f, 1 },
                    { 2, 2, false, 3f, 1 },
                    { 3, 3, false, 3.5f, 1 },
                    { 4, 4, false, 4f, 1 },
                    { 5, 5, false, 2f, 1 },
                    { 6, 6, false, 3.2f, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
