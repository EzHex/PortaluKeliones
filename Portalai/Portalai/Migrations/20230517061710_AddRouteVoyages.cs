using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portalai.Migrations
{
    public partial class AddRouteVoyages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Zarasai - Rokiškis - Panevėžys - Šiauliai - Plungė - Palanga - Klaipėda" });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "Vilnius - Kaunas - Raseiniai - Kryžkalnis - Klaipėda" });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "Rokiškis - Anykščiai - Ukmergė - Jonava - Kaunas" });

            migrationBuilder.InsertData(
                table: "RouteVoyages",
                columns: new[] { "Id", "ArrivalPlaceId", "DeparturePlaceId", "Duration", "Order", "RouteId" },
                values: new object[,]
                {
                    { 1, 30, 22, 70, 1, 3 },
                    { 2, 14, 30, 50, 2, 3 },
                    { 3, 9, 14, 40, 3, 3 },
                    { 4, 3, 9, 45, 4, 3 },
                    { 5, 2, 1, 105, 1, 2 },
                    { 6, 27, 2, 90, 2, 2 },
                    { 7, 3, 27, 150, 3, 2 },
                    { 8, 22, 38, 90, 1, 1 },
                    { 9, 4, 22, 120, 2, 1 },
                    { 10, 5, 4, 120, 3, 1 },
                    { 11, 17, 5, 120, 4, 1 },
                    { 12, 16, 17, 65, 5, 1 },
                    { 13, 3, 16, 30, 6, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RouteVoyages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RouteVoyages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RouteVoyages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RouteVoyages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RouteVoyages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RouteVoyages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RouteVoyages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RouteVoyages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RouteVoyages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RouteVoyages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RouteVoyages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RouteVoyages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RouteVoyages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
