using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthorizationMicroservice.Migrations
{
    public partial class UpdatedTheDataTypesofUniversityId2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginDetails",
                table: "LoginDetails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LoginDetails");

            migrationBuilder.AlterColumn<string>(
                name: "UniversityId",
                table: "LoginDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginDetails",
                table: "LoginDetails",
                column: "UniversityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginDetails",
                table: "LoginDetails");

            migrationBuilder.AlterColumn<string>(
                name: "UniversityId",
                table: "LoginDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LoginDetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginDetails",
                table: "LoginDetails",
                column: "Id");
        }
    }
}
