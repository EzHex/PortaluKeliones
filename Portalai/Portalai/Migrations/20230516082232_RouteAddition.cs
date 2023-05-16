using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portalai.Migrations
{
    public partial class RouteAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Trips_TripId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteVoyages_Routes_RoutesId",
                table: "RouteVoyages");

            migrationBuilder.DropTable(
                name: "EducationalRoutePlace");

            migrationBuilder.DropTable(
                name: "PlaceRouteVoyage");

            migrationBuilder.DropIndex(
                name: "IX_Routes_TripId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Routes");

            migrationBuilder.RenameColumn(
                name: "RoutesId",
                table: "RouteVoyages",
                newName: "RouteId");

            migrationBuilder.RenameIndex(
                name: "IX_RouteVoyages_RoutesId",
                table: "RouteVoyages",
                newName: "IX_RouteVoyages_RouteId");

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Voyages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArrivalPlaceId",
                table: "RouteVoyages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeparturePlaceId",
                table: "RouteVoyages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EducationalRouteId",
                table: "Places",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voyages_TripId",
                table: "Voyages",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_RouteId",
                table: "Trips",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteVoyages_ArrivalPlaceId",
                table: "RouteVoyages",
                column: "ArrivalPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteVoyages_DeparturePlaceId",
                table: "RouteVoyages",
                column: "DeparturePlaceId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RouteVoyages_Places_ArrivalPlaceId",
                table: "RouteVoyages",
                column: "ArrivalPlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteVoyages_Places_DeparturePlaceId",
                table: "RouteVoyages",
                column: "DeparturePlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteVoyages_Routes_RouteId",
                table: "RouteVoyages",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Routes_RouteId",
                table: "Trips",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voyages_Trips_TripId",
                table: "Voyages",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_EducationalRoutes_EducationalRouteId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteVoyages_Places_ArrivalPlaceId",
                table: "RouteVoyages");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteVoyages_Places_DeparturePlaceId",
                table: "RouteVoyages");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteVoyages_Routes_RouteId",
                table: "RouteVoyages");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Routes_RouteId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Voyages_Trips_TripId",
                table: "Voyages");

            migrationBuilder.DropIndex(
                name: "IX_Voyages_TripId",
                table: "Voyages");

            migrationBuilder.DropIndex(
                name: "IX_Trips_RouteId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_RouteVoyages_ArrivalPlaceId",
                table: "RouteVoyages");

            migrationBuilder.DropIndex(
                name: "IX_RouteVoyages_DeparturePlaceId",
                table: "RouteVoyages");

            migrationBuilder.DropIndex(
                name: "IX_Places_EducationalRouteId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Voyages");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ArrivalPlaceId",
                table: "RouteVoyages");

            migrationBuilder.DropColumn(
                name: "DeparturePlaceId",
                table: "RouteVoyages");

            migrationBuilder.DropColumn(
                name: "EducationalRouteId",
                table: "Places");

            migrationBuilder.RenameColumn(
                name: "RouteId",
                table: "RouteVoyages",
                newName: "RoutesId");

            migrationBuilder.RenameIndex(
                name: "IX_RouteVoyages_RouteId",
                table: "RouteVoyages",
                newName: "IX_RouteVoyages_RoutesId");

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateTable(
                name: "PlaceRouteVoyage",
                columns: table => new
                {
                    PlacesId = table.Column<int>(type: "int", nullable: false),
                    RouteVoyagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceRouteVoyage", x => new { x.PlacesId, x.RouteVoyagesId });
                    table.ForeignKey(
                        name: "FK_PlaceRouteVoyage_Places_PlacesId",
                        column: x => x.PlacesId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceRouteVoyage_RouteVoyages_RouteVoyagesId",
                        column: x => x.RouteVoyagesId,
                        principalTable: "RouteVoyages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_TripId",
                table: "Routes",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalRoutePlace_PlacesId",
                table: "EducationalRoutePlace",
                column: "PlacesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceRouteVoyage_RouteVoyagesId",
                table: "PlaceRouteVoyage",
                column: "RouteVoyagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Trips_TripId",
                table: "Routes",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteVoyages_Routes_RoutesId",
                table: "RouteVoyages",
                column: "RoutesId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
