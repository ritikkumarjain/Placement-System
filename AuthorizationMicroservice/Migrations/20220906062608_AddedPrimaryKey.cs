using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthorizationMicroservice.Migrations
{
    public partial class AddedPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "LoginDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginDetails",
                table: "LoginDetails",
                column: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginDetails",
                table: "LoginDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "LoginDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
