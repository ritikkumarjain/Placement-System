using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthorizationMicroservice.Migrations
{
    public partial class RemovedRegistrationNumberField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "LoginDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "LoginDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
