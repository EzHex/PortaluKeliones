using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portalai.Migrations
{
    public partial class EducationalFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_EducationalRoutes_EducationalRouteId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_EducationalRouteId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "EducationalRouteId",
                table: "Places");

            migrationBuilder.CreateTable(
                name: "EducationalRoutePlace",
                columns: table => new
                {
                    EducationalRoutesId = table.Column<int>(type: "int", nullable: false),
                    PlacesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalRoutePlace", x => new { x.EducationalRoutesId, x.PlacesId });
                    table.ForeignKey(
                        name: "FK_EducationalRoutePlace_EducationalRoutes_EducationalRoutesId",
                        column: x => x.EducationalRoutesId,
                        principalTable: "EducationalRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationalRoutePlace_Places_PlacesId",
                        column: x => x.PlacesId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationalRoutePlace_PlacesId",
                table: "EducationalRoutePlace",
                column: "PlacesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationalRoutePlace");

            migrationBuilder.AddColumn<int>(
                name: "EducationalRouteId",
                table: "Places",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Places_EducationalRouteId",
                table: "Places",
                column: "EducationalRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_EducationalRoutes_EducationalRouteId",
                table: "Places",
                column: "EducationalRouteId",
                principalTable: "EducationalRoutes",
                principalColumn: "Id");
        }
    }
}
