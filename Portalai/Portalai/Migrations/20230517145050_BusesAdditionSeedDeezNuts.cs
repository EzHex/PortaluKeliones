using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portalai.Migrations
{
    public partial class BusesAdditionSeedDeezNuts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "Brand", "Fuel", "LicensePlate", "ManufactureDate", "Model", "Seats", "Status" },
                values: new object[,]
                {
                    { 1, "Opel", 3, "ABC 123", new DateTime(2018, 5, 17, 17, 50, 49, 958, DateTimeKind.Local).AddTicks(4643), "Vivado", 42, 0 },
                    { 2, "Opel", 0, "BCA 234", new DateTime(2021, 5, 17, 17, 50, 49, 958, DateTimeKind.Local).AddTicks(4682), "Vivado", 54, 0 },
                    { 3, "Arnas", 1, "CDE 345", new DateTime(2016, 5, 17, 17, 50, 49, 958, DateTimeKind.Local).AddTicks(4684), "Gaming", 12, 0 },
                    { 4, "Arnas", 4, "DEF 456", new DateTime(2011, 5, 17, 17, 50, 49, 958, DateTimeKind.Local).AddTicks(4686), "Driving", 34, 0 },
                    { 5, "Mad Lions", 1, "EFG 567", new DateTime(2009, 5, 17, 17, 50, 49, 958, DateTimeKind.Local).AddTicks(4688), "Base", 57, 0 },
                    { 6, "Mad Lions", 4, "FGH 678", new DateTime(2015, 5, 17, 17, 50, 49, 958, DateTimeKind.Local).AddTicks(4690), "Express", 86, 0 },
                    { 7, "Mode", 0, "GHI 789", new DateTime(2017, 5, 17, 17, 50, 49, 958, DateTimeKind.Local).AddTicks(4698), "Driving", 56, 0 },
                    { 8, "Mode", 0, "JKL 890", new DateTime(2022, 5, 17, 17, 50, 49, 958, DateTimeKind.Local).AddTicks(4700), "Trolling", 21, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
