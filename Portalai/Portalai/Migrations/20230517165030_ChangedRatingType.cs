using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portalai.Migrations
{
    public partial class ChangedRatingType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "EducationalRoutes",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ManufactureDate",
                value: new DateTime(2018, 5, 17, 19, 50, 30, 451, DateTimeKind.Local).AddTicks(9600));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 2,
                column: "ManufactureDate",
                value: new DateTime(2021, 5, 17, 19, 50, 30, 451, DateTimeKind.Local).AddTicks(9633));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 3,
                column: "ManufactureDate",
                value: new DateTime(2016, 5, 17, 19, 50, 30, 451, DateTimeKind.Local).AddTicks(9637));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 4,
                column: "ManufactureDate",
                value: new DateTime(2011, 5, 17, 19, 50, 30, 451, DateTimeKind.Local).AddTicks(9640));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 5,
                column: "ManufactureDate",
                value: new DateTime(2009, 5, 17, 19, 50, 30, 451, DateTimeKind.Local).AddTicks(9643));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 6,
                column: "ManufactureDate",
                value: new DateTime(2015, 5, 17, 19, 50, 30, 451, DateTimeKind.Local).AddTicks(9646));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 7,
                column: "ManufactureDate",
                value: new DateTime(2017, 5, 17, 19, 50, 30, 451, DateTimeKind.Local).AddTicks(9649));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 8,
                column: "ManufactureDate",
                value: new DateTime(2022, 5, 17, 19, 50, 30, 451, DateTimeKind.Local).AddTicks(9652));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "EducationalRoutes",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

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
        }
    }
}
