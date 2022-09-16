using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthorizationMicroservice.Migrations
{
    public partial class UpdateUserNameWithUniverityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginDetails",
                table: "LoginDetails");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "LoginDetails");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LoginDetails",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "UniversityId",
                table: "LoginDetails",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginDetails",
                table: "LoginDetails",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginDetails",
                table: "LoginDetails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LoginDetails");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "LoginDetails");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "LoginDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginDetails",
                table: "LoginDetails",
                column: "Username");
        }
    }
}
