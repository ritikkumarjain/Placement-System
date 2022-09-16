using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentMicroservice.Migrations
{
    public partial class AddedStudentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudentsDetails",
                newName: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentsDetails",
                newName: "Id");
        }
    }
}
