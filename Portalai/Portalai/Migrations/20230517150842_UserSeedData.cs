using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portalai.Migrations
{
    public partial class UserSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ManufactureDate",
                value: new DateTime(2018, 5, 17, 18, 8, 41, 867, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 2,
                column: "ManufactureDate",
                value: new DateTime(2021, 5, 17, 18, 8, 41, 867, DateTimeKind.Local).AddTicks(2663));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 3,
                column: "ManufactureDate",
                value: new DateTime(2016, 5, 17, 18, 8, 41, 867, DateTimeKind.Local).AddTicks(2667));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 4,
                column: "ManufactureDate",
                value: new DateTime(2011, 5, 17, 18, 8, 41, 867, DateTimeKind.Local).AddTicks(2671));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 5,
                column: "ManufactureDate",
                value: new DateTime(2009, 5, 17, 18, 8, 41, 867, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 6,
                column: "ManufactureDate",
                value: new DateTime(2015, 5, 17, 18, 8, 41, 867, DateTimeKind.Local).AddTicks(2677));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 7,
                column: "ManufactureDate",
                value: new DateTime(2017, 5, 17, 18, 8, 41, 867, DateTimeKind.Local).AddTicks(2681));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 8,
                column: "ManufactureDate",
                value: new DateTime(2022, 5, 17, 18, 8, 41, 867, DateTimeKind.Local).AddTicks(2684));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Phone", "Role" },
                values: new object[,]
                {
                    { 1, "Arnas@PortalsDB.com", "Arnas", "UUID", "860000000", 1 },
                    { 2, "Modestas@PortalsDB.com", "Modestas", "UUID", "860000000", 0 },
                    { 3, "Viktorija@PortalsDB.com", "Viktorija", "UUID", "860000000", 3 },
                    { 4, "Dominykas@PortalsDB.com", "Dominykas", "UUID", "860000000", 2 },
                    { 5, "Karolis@PortalsDB.com", "Karolis", "UUID", "860000000", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ManufactureDate",
                value: new DateTime(2018, 5, 17, 17, 50, 49, 958, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 2,
                column: "ManufactureDate",
                value: new DateTime(2021, 5, 17, 17, 50, 49, 958, DateTimeKind.Local).AddTicks(4682));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 3,
                column: "ManufactureDate",
                value: new DateTime(2016, 5, 17, 17, 50, 49, 958, DateTimeKind.Local).AddTicks(4684));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 4,
                column: "ManufactureDate",
                value: new DateTime(2011, 5, 17, 17, 50, 49, 958, DateTimeKind.Local).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 5,
                column: "ManufactureDate",
                value: new DateTime(2009, 5, 17, 17, 50, 49, 958, DateTimeKind.Local).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 6,
                column: "ManufactureDate",
                value: new DateTime(2015, 5, 17, 17, 50, 49, 958, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 7,
                column: "ManufactureDate",
                value: new DateTime(2017, 5, 17, 17, 50, 49, 958, DateTimeKind.Local).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 8,
                column: "ManufactureDate",
                value: new DateTime(2022, 5, 17, 17, 50, 49, 958, DateTimeKind.Local).AddTicks(4700));
        }
    }
}
