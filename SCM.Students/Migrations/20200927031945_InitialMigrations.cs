using Microsoft.EntityFrameworkCore.Migrations;

namespace SCM.Students.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    RollNo = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 70, nullable: true),
                    Phone = table.Column<string>(maxLength: 15, nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Email", "IsDeleted", "Name", "Phone", "RollNo" },
                values: new object[,]
                {
                    { 1, "Lahore, Pakistan", "azhar@test.com", false, "Azhar Riaz", "+923416311582", "RLNO-123" },
                    { 2, "Lahore, Pakistan", "muzammil@test.com", false, "Muzammil Ali", "+923416313452", "RLNO-124" },
                    { 3, "Bahawalpur, Pakistan", "awais234@test.com", false, "Awais Ali", "+923416313098", "RLNO-125" },
                    { 4, "Qusoor, Pakistan", "sheharyar04@test.com", false, "Sheharyar Akram", "+923416378798", "RLNO-126" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
