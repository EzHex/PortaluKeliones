using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portalai.Migrations
{
    public partial class CDsNuts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Portals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ManufactureDate",
                value: new DateTime(2018, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 2,
                column: "ManufactureDate",
                value: new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 3,
                column: "ManufactureDate",
                value: new DateTime(2016, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 4,
                column: "ManufactureDate",
                value: new DateTime(2011, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 5,
                column: "ManufactureDate",
                value: new DateTime(2009, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 6,
                column: "ManufactureDate",
                value: new DateTime(2015, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 7,
                column: "ManufactureDate",
                value: new DateTime(2017, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 8,
                column: "ManufactureDate",
                value: new DateTime(2018, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Portals",
                columns: new[] { "Id", "CurrentLiquidLevel", "Latitude", "LiquidCapacity", "Longitude", "Name", "PortalJunctionId", "Status", "TeleportCount", "TeleportPrice" },
                values: new object[,]
                {
                    { 1, 2.0, 0.0, 3.0, 0.0, "Vilnius", null, 0, 0.0, 0.0 },
                    { 2, 10.0, 1.0, 30.0, 1.0, "Kaunas", null, 2, 0.0, 0.0 },
                    { 3, 20.0, 2.0, 20.0, 2.0, "Klaipeda", null, 1, 0.0, 0.0 },
                    { 4, 20.0, 3.0, 20.0, -3.0, "Panevezys", null, 3, 0.0, 0.0 }
                });

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: 3);

            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "Id", "Description", "PortalId", "Status", "SubmisionDate", "UserId" },
                values: new object[] { 1, "Portalas Vilnius yra nepasiekiamas", 1, 0, new DateTime(2023, 5, 4, 4, 35, 52, 856, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "Id", "Description", "PortalId", "Status", "SubmisionDate", "UserId" },
                values: new object[] { 2, "Nu neveikia tas Vilniaus portalas nesamone kazkoke ce", 2, 1, new DateTime(2023, 5, 4, 4, 35, 52, 856, DateTimeKind.Unspecified), 4 });

            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "Id", "Description", "PortalId", "Status", "SubmisionDate", "UserId" },
                values: new object[] { 3, "Nemoku naudotis portalu padekit", 3, 3, new DateTime(2023, 5, 4, 4, 38, 52, 856, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "ComplaintHistories",
                columns: new[] { "Id", "Comment", "ComplaintId", "Date", "Status" },
                values: new object[,]
                {
                    { 1, "Portalas Vilnius yra nepasiekiamas", 1, new DateTime(2023, 5, 4, 4, 35, 52, 856, DateTimeKind.Unspecified), 0 },
                    { 2, "Portalas Vilnius yra nepasiekiamas", 2, new DateTime(2023, 5, 4, 7, 35, 52, 856, DateTimeKind.Unspecified), 0 },
                    { 3, "Aptiktas ortalo skysčio lygio trūkumas. Problema pradėta spręsti", 2, new DateTime(2023, 5, 4, 8, 35, 52, 856, DateTimeKind.Unspecified), 1 },
                    { 4, "Nemoku naudotis portalu padekit", 3, new DateTime(2023, 5, 4, 6, 35, 52, 856, DateTimeKind.Unspecified), 0 },
                    { 5, "Klaidingas pranešimas, portalas veikia", 3, new DateTime(2023, 5, 4, 6, 35, 52, 856, DateTimeKind.Unspecified), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ComplaintHistories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComplaintHistories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComplaintHistories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComplaintHistories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ComplaintHistories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Portals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Complaints",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Complaints",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Complaints",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Portals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Portals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Portals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Portals");

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ManufactureDate",
                value: new DateTime(2018, 5, 21, 4, 56, 57, 121, DateTimeKind.Local).AddTicks(8349));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 2,
                column: "ManufactureDate",
                value: new DateTime(2021, 5, 21, 4, 56, 57, 121, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 3,
                column: "ManufactureDate",
                value: new DateTime(2016, 5, 21, 4, 56, 57, 121, DateTimeKind.Local).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 4,
                column: "ManufactureDate",
                value: new DateTime(2011, 5, 21, 4, 56, 57, 121, DateTimeKind.Local).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 5,
                column: "ManufactureDate",
                value: new DateTime(2009, 5, 21, 4, 56, 57, 121, DateTimeKind.Local).AddTicks(8388));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 6,
                column: "ManufactureDate",
                value: new DateTime(2015, 5, 21, 4, 56, 57, 121, DateTimeKind.Local).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 7,
                column: "ManufactureDate",
                value: new DateTime(2017, 5, 21, 4, 56, 57, 121, DateTimeKind.Local).AddTicks(8392));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 8,
                column: "ManufactureDate",
                value: new DateTime(2022, 5, 21, 4, 56, 57, 121, DateTimeKind.Local).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: 0);
        }
    }
}
