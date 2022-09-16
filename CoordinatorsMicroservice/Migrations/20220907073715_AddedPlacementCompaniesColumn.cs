using Microsoft.EntityFrameworkCore.Migrations;

namespace CoordinatorsMicroservice.Migrations
{
    public partial class AddedPlacementCompaniesColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlacementCount",
                table: "StudentsPlacementDetails");

            migrationBuilder.AddColumn<string>(
                name: "PlacementCompanyI",
                table: "StudentsPlacementDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlacementCompanyII",
                table: "StudentsPlacementDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlacementCompanyI",
                table: "StudentsPlacementDetails");

            migrationBuilder.DropColumn(
                name: "PlacementCompanyII",
                table: "StudentsPlacementDetails");

            migrationBuilder.AddColumn<int>(
                name: "PlacementCount",
                table: "StudentsPlacementDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
