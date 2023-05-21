using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portalai.Migrations
{
    public partial class SurveySquash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portals_PortalJunctions_PortalJunctionId",
                table: "Portals");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Trips_TripId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteVoyages_Routes_RoutesId",
                table: "RouteVoyages");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestionOptions_QuestionAnswers_QuestionAnswerId",
                table: "SurveyQuestionOptions");

            migrationBuilder.DropTable(
                name: "PlaceRouteVoyage");

            migrationBuilder.DropIndex(
                name: "IX_SurveyQuestionOptions_QuestionAnswerId",
                table: "SurveyQuestionOptions");

            migrationBuilder.DropIndex(
                name: "IX_Routes_TripId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "SurveyQuestionOptions");

            migrationBuilder.DropColumn(
                name: "QuestionAnswerId",
                table: "SurveyQuestionOptions");

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "RouteVoyages");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "RouteVoyages");

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
                name: "Duration",
                table: "RouteVoyages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SurveyAnswerId",
                table: "QuestionAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PortalJunctionId",
                table: "Portals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "EducationalRoutes",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Complaints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QuestionAnswerSurveyQuestionOption",
                columns: table => new
                {
                    QuestionAnswersId = table.Column<int>(type: "int", nullable: false),
                    SurveyQuestionOptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswerSurveyQuestionOption", x => new { x.QuestionAnswersId, x.SurveyQuestionOptionsId });
                    table.ForeignKey(
                        name: "FK_QuestionAnswerSurveyQuestionOption_QuestionAnswers_QuestionAnswersId",
                        column: x => x.QuestionAnswersId,
                        principalTable: "QuestionAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_QuestionAnswerSurveyQuestionOption_SurveyQuestionOptions_SurveyQuestionOptionsId",
                        column: x => x.SurveyQuestionOptionsId,
                        principalTable: "SurveyQuestionOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "Brand", "Fuel", "LicensePlate", "ManufactureDate", "Model", "Seats", "Status" },
                values: new object[,]
                {
                    { 1, "Opel", 3, "ABC 123", new DateTime(2018, 5, 21, 4, 19, 58, 780, DateTimeKind.Local).AddTicks(4145), "Vivado", 42, 0 },
                    { 2, "Opel", 0, "BCA 234", new DateTime(2021, 5, 21, 4, 19, 58, 780, DateTimeKind.Local).AddTicks(4188), "Vivado", 54, 0 },
                    { 3, "Arnas", 1, "CDE 345", new DateTime(2016, 5, 21, 4, 19, 58, 780, DateTimeKind.Local).AddTicks(4191), "Gaming", 12, 0 },
                    { 4, "Arnas", 4, "DEF 456", new DateTime(2011, 5, 21, 4, 19, 58, 780, DateTimeKind.Local).AddTicks(4194), "Driving", 34, 0 },
                    { 5, "Mad Lions", 1, "EFG 567", new DateTime(2009, 5, 21, 4, 19, 58, 780, DateTimeKind.Local).AddTicks(4197), "Base", 57, 0 },
                    { 6, "Mad Lions", 4, "FGH 678", new DateTime(2015, 5, 21, 4, 19, 58, 780, DateTimeKind.Local).AddTicks(4199), "Express", 86, 0 },
                    { 7, "Mode", 0, "GHI 789", new DateTime(2017, 5, 21, 4, 19, 58, 780, DateTimeKind.Local).AddTicks(4202), "Driving", 56, 0 },
                    { 8, "Mode", 0, "JKL 890", new DateTime(2022, 5, 21, 4, 19, 58, 780, DateTimeKind.Local).AddTicks(4205), "Trolling", 21, 0 }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, 25.280000000000001, 54.687199999999997, "Vilnius" },
                    { 2, 23.886099999999999, 54.897199999999998, "Kaunas" },
                    { 3, 21.166699999999999, 55.75, "Klaipeda" },
                    { 4, 24.350000000000001, 55.7333, "Panevezys" },
                    { 5, 23.316700000000001, 55.933300000000003, "Siauliai" },
                    { 6, 24.049199999999999, 54.401400000000002, "Alytus" },
                    { 7, 23.350000000000001, 54.547199999999997, "Marijampole" },
                    { 8, 22.333300000000001, 56.316699999999997, "Mazeikiai" },
                    { 9, 24.2806, 55.072200000000002, "Jonava" },
                    { 10, 25.600000000000001, 55.5, "Utena" },
                    { 11, 23.966699999999999, 55.283299999999997, "Kedainiai" },
                    { 12, 22.25, 55.9833, "Telsiai" },
                    { 13, 22.2897, 55.252200000000002, "Taurage" },
                    { 14, 24.75, 55.25, "Ukmerge" },
                    { 15, 26.437999999999999, 55.597999999999999, "Visaginas" },
                    { 16, 21.066700000000001, 55.916699999999999, "Palanga" },
                    { 17, 21.850000000000001, 55.916699999999999, "Plunge" },
                    { 18, 21.2422, 55.890000000000001, "Kretinga" },
                    { 19, 21.4833, 55.350000000000001, "Silute" },
                    { 20, 23.550000000000001, 55.799999999999997, "Radviliskis" },
                    { 21, 23.966699999999999, 54.0167, "Druskininkai" },
                    { 22, 25.583300000000001, 55.966700000000003, "Rokiskis" },
                    { 23, 24.661100000000001, 54.786099999999998, "Elektrenai" },
                    { 24, 22.7667, 55.083300000000001, "Jurbarkas" },
                    { 25, 24.75, 56.200000000000003, "Birzai" },
                    { 26, 23.033300000000001, 54.649999999999999, "Vilkaviskis" },
                    { 27, 23.116700000000002, 55.366700000000002, "Raseiniai" },
                    { 28, 23.941700000000001, 54.633299999999998, "Prienai" },
                    { 29, 23.600000000000001, 56.2333, "Joniskis" },
                    { 30, 25.100000000000001, 55.533299999999997, "Anyksciai" },
                    { 31, 24.572199999999999, 54.211100000000002, "Varena" },
                    { 32, 24.449999999999999, 54.866700000000002, "Kaisiadorys" },
                    { 33, 22.899999999999999, 56.316699999999997, "Naujoji Akmene" },
                    { 34, 22.933299999999999, 55.633299999999998, "Kelme" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 35, 25.383299999999998, 54.316699999999997, "Salcininkai" },
                    { 36, 24.403600000000001, 56.059399999999997, "Pasvalys" },
                    { 37, 24.966699999999999, 55.833300000000001, "Kupiskis" },
                    { 38, 26.25, 55.7333, "Zarasai" },
                    { 39, 24.933299999999999, 54.633299999999998, "Trakai" },
                    { 40, 25.416699999999999, 55.2333, "Moletai" },
                    { 41, 23.5, 54.75, "Kazlu Ruda" },
                    { 42, 23.050000000000001, 54.950000000000003, "Sakiai" },
                    { 43, 21.533300000000001, 56.2667, "Skuodas" },
                    { 44, 26.166699999999999, 55.350000000000001, "Ignalina" },
                    { 45, 22.183299999999999, 55.4833, "Silale" },
                    { 46, 23.866700000000002, 55.966700000000003, "Pakruojis" },
                    { 47, 26.1556, 55.133299999999998, "Svencionys" },
                    { 48, 23.216699999999999, 54.416699999999999, "Kalvarija" },
                    { 49, 23.5167, 54.2333, "Lazdijai" },
                    { 50, 21.933299999999999, 55.716700000000003, "Rietavas" },
                    { 51, 24.020600000000002, 54.602800000000002, "Birstonas" },
                    { 52, 21.005600000000001, 55.3033, "Nida" },
                    { 53, 24.9694, 55.036099999999998, "Sirvintos" },
                    { 54, 21.916699999999999, 55.133299999999998, "Pagegiai" },
                    { 55, 21.403300000000002, 55.712800000000001, "Gargzdai" },
                    { 56, 25.199999999999999, 54.600000000000001, "Aukstieji Paneriai" },
                    { 57, 25.100000000000001, 54.666699999999999, "Grigiskes" },
                    { 58, 22.916699999999999, 55.9833, "Kursenai" },
                    { 59, 23.997, 54.395000000000003, "Likiskiai" },
                    { 60, 23.866700000000002, 54.816699999999997, "Garliava" },
                    { 61, 25.066700000000001, 54.649999999999999, "Lentvaris" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Zarasai - Rokiškis - Panevėžys - Šiauliai - Plungė - Palanga - Klaipėda" },
                    { 2, "Vilnius - Kaunas - Raseiniai - Kryžkalnis - Klaipėda" },
                    { 3, "Rokiškis - Anykščiai - Ukmergė - Jonava - Kaunas" }
                });

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
                name: "IX_QuestionAnswers_SurveyAnswerId",
                table: "QuestionAnswers",
                column: "SurveyAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_UserId",
                table: "Complaints",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswerSurveyQuestionOption_SurveyQuestionOptionsId",
                table: "QuestionAnswerSurveyQuestionOption",
                column: "SurveyQuestionOptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Users_UserId",
                table: "Complaints",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portals_PortalJunctions_PortalJunctionId",
                table: "Portals",
                column: "PortalJunctionId",
                principalTable: "PortalJunctions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_SurveyAnswers_SurveyAnswerId",
                table: "QuestionAnswers",
                column: "SurveyAnswerId",
                principalTable: "SurveyAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

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
                name: "FK_Complaints_Users_UserId",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Portals_PortalJunctions_PortalJunctionId",
                table: "Portals");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_SurveyAnswers_SurveyAnswerId",
                table: "QuestionAnswers");

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

            migrationBuilder.DropTable(
                name: "QuestionAnswerSurveyQuestionOption");

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
                name: "IX_QuestionAnswers_SurveyAnswerId",
                table: "QuestionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_UserId",
                table: "Complaints");

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

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 61);

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

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 38);

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
                name: "Duration",
                table: "RouteVoyages");

            migrationBuilder.DropColumn(
                name: "SurveyAnswerId",
                table: "QuestionAnswers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Complaints");

            migrationBuilder.RenameColumn(
                name: "RouteId",
                table: "RouteVoyages",
                newName: "RoutesId");

            migrationBuilder.RenameIndex(
                name: "IX_RouteVoyages_RouteId",
                table: "RouteVoyages",
                newName: "IX_RouteVoyages_RoutesId");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "SurveyQuestionOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionAnswerId",
                table: "SurveyQuestionOptions",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PortalJunctionId",
                table: "Portals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "EducationalRoutes",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

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
                name: "IX_SurveyQuestionOptions_QuestionAnswerId",
                table: "SurveyQuestionOptions",
                column: "QuestionAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_TripId",
                table: "Routes",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceRouteVoyage_RouteVoyagesId",
                table: "PlaceRouteVoyage",
                column: "RouteVoyagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portals_PortalJunctions_PortalJunctionId",
                table: "Portals",
                column: "PortalJunctionId",
                principalTable: "PortalJunctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestionOptions_QuestionAnswers_QuestionAnswerId",
                table: "SurveyQuestionOptions",
                column: "QuestionAnswerId",
                principalTable: "QuestionAnswers",
                principalColumn: "Id");
        }
    }
}
