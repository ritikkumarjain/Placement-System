using Microsoft.EntityFrameworkCore.Migrations;

namespace CoordinatorsMicroservice.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentsPlacementDetails",
                columns: table => new
                {
                    PlacementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlacementCount = table.Column<int>(nullable: false),
                    PlacementTypeI = table.Column<string>(nullable: true),
                    PlacementTypeII = table.Column<string>(nullable: true),
                    UniversityId = table.Column<long>(nullable: false),
                    RegistrationNumber = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsPlacementDetails", x => x.PlacementId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsPlacementDetails");
        }
    }
}
