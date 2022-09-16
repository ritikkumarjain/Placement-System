using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentMicroservice.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentsDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityId = table.Column<long>(type: "bigint", nullable: false),
                    RegistrationNumber = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semester = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstSem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondSem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdSem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthSem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FifthSem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SixthSem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeventhSem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EigthSem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsDetails");
        }
    }
}
