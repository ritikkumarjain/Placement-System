using Microsoft.EntityFrameworkCore.Migrations;

namespace CoordinatorsMicroservice.Migrations
{
    public partial class ChangedDataTypeFromLongToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UniversityId",
                table: "StudentsPlacementDetails",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "StudentsPlacementDetails",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UniversityId",
                table: "StudentsPlacementDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RegistrationNumber",
                table: "StudentsPlacementDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
