using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portalai.Migrations
{
    public partial class SurveySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "Description", "EndDate", "StartDate", "Status", "Title" },
                values: new object[] { 1, "Ši apklausa skirta išsiašikinti vienam ir visam kaip žmonės valgo šaltibarščius.", new DateTime(2023, 6, 4, 4, 35, 52, 856, DateTimeKind.Unspecified), new DateTime(2023, 5, 21, 4, 35, 52, 856, DateTimeKind.Unspecified), 0, "Šaltibarščių valgymo ypatumai" });

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "Id", "IsRequired", "Order", "Question", "SurveyId", "Type" },
                values: new object[] { 1, false, 0, "Ar pučiate valgydami šaltibarščius ?", 1, 1 });

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "Id", "IsRequired", "Order", "Question", "SurveyId", "Type" },
                values: new object[] { 2, false, 0, "Kaip dažnai valgote šaltibarščius ?", 1, 2 });

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "Id", "IsRequired", "Order", "Question", "SurveyId", "Type" },
                values: new object[] { 3, false, 0, "Kaip galėtumėme pagerinti šią apklausą ?", 1, 0 });

            migrationBuilder.InsertData(
                table: "SurveyQuestionOptions",
                columns: new[] { "Id", "SurveyQuestionId", "Text" },
                values: new object[,]
                {
                    { 1, 1, "Taip" },
                    { 2, 1, "Ne" },
                    { 3, 2, "Nevalgau" },
                    { 4, 2, "Kartą į metus" },
                    { 5, 2, "Retai" },
                    { 6, 2, "Vasarą" },
                    { 7, 2, "Šaltibarščiai tai mano gyvenimas" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SurveyQuestionOptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SurveyQuestionOptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SurveyQuestionOptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SurveyQuestionOptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SurveyQuestionOptions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SurveyQuestionOptions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SurveyQuestionOptions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ManufactureDate",
                value: new DateTime(2018, 5, 21, 4, 19, 58, 780, DateTimeKind.Local).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 2,
                column: "ManufactureDate",
                value: new DateTime(2021, 5, 21, 4, 19, 58, 780, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 3,
                column: "ManufactureDate",
                value: new DateTime(2016, 5, 21, 4, 19, 58, 780, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 4,
                column: "ManufactureDate",
                value: new DateTime(2011, 5, 21, 4, 19, 58, 780, DateTimeKind.Local).AddTicks(4194));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 5,
                column: "ManufactureDate",
                value: new DateTime(2009, 5, 21, 4, 19, 58, 780, DateTimeKind.Local).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 6,
                column: "ManufactureDate",
                value: new DateTime(2015, 5, 21, 4, 19, 58, 780, DateTimeKind.Local).AddTicks(4199));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 7,
                column: "ManufactureDate",
                value: new DateTime(2017, 5, 21, 4, 19, 58, 780, DateTimeKind.Local).AddTicks(4202));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 8,
                column: "ManufactureDate",
                value: new DateTime(2022, 5, 21, 4, 19, 58, 780, DateTimeKind.Local).AddTicks(4205));
        }
    }
}
