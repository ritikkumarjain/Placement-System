using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthorizationMicroservice.Migrations
{
    public partial class AddedRegistrationNumberField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "LoginDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "LoginDetails");
        }
    }
}
