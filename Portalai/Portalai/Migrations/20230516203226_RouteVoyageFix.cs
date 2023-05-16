using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portalai.Migrations
{
    public partial class RouteVoyageFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "RouteVoyages");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "RouteVoyages");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "RouteVoyages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "RouteVoyages");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalTime",
                table: "RouteVoyages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "RouteVoyages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
