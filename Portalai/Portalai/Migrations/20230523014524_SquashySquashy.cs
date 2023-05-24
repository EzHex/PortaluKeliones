using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portalai.Migrations
{
    public partial class SquashySquashy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fuel = table.Column<int>(type: "int", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationalRoutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    RatingCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalRoutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortalJunctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalJunctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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
                name: "Portals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    LiquidCapacity = table.Column<double>(type: "float", nullable: false),
                    CurrentLiquidLevel = table.Column<double>(type: "float", nullable: false),
                    TeleportPrice = table.Column<double>(type: "float", nullable: false),
                    TeleportCount = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PortalJunctionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portals_PortalJunctions_PortalJunctionId",
                        column: x => x.PortalJunctionId,
                        principalTable: "PortalJunctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RouteVoyages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    ArrivalId = table.Column<int>(type: "int", nullable: false),
                    DepartureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteVoyages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteVoyages_Places_ArrivalId",
                        column: x => x.ArrivalId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RouteVoyages_Places_DepartureId",
                        column: x => x.DepartureId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RouteVoyages_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trips_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyAnswers_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyQuestions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmisionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PortalId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaints_Portals_PortalId",
                        column: x => x.PortalId,
                        principalTable: "Portals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Complaints_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seat = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voyages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    RouteVoyageId = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voyages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voyages_RouteVoyages_RouteVoyageId",
                        column: x => x.RouteVoyageId,
                        principalTable: "RouteVoyages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voyages_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyQuestionId = table.Column<int>(type: "int", nullable: false),
                    SurveyAnswerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_SurveyAnswers_SurveyAnswerId",
                        column: x => x.SurveyAnswerId,
                        principalTable: "SurveyAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_SurveyQuestions_SurveyQuestionId",
                        column: x => x.SurveyQuestionId,
                        principalTable: "SurveyQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestionOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyQuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyQuestionOptions_SurveyQuestions_SurveyQuestionId",
                        column: x => x.SurveyQuestionId,
                        principalTable: "SurveyQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplaintId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintHistories_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswerSurveyQuestionOption_SurveyQuestionOptions_SurveyQuestionOptionsId",
                        column: x => x.SurveyQuestionOptionsId,
                        principalTable: "SurveyQuestionOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "Brand", "Fuel", "LicensePlate", "ManufactureDate", "Model", "Seats", "Status" },
                values: new object[,]
                {
                    { 1, "Opel", 3, "ABC 123", new DateTime(2018, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vivado", 42, 0 },
                    { 2, "Opel", 0, "BCA 234", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vivado", 54, 0 },
                    { 3, "Arnas", 1, "CDE 345", new DateTime(2016, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming", 12, 0 },
                    { 4, "Arnas", 4, "DEF 456", new DateTime(2011, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Driving", 34, 0 },
                    { 5, "Mad Lions", 1, "EFG 567", new DateTime(2009, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Base", 57, 0 },
                    { 6, "Mad Lions", 4, "FGH 678", new DateTime(2015, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Express", 86, 0 },
                    { 7, "Mode", 0, "GHI 789", new DateTime(2017, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Driving", 56, 0 },
                    { 8, "Mode", 0, "JKL 890", new DateTime(2018, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trolling", 21, 0 }
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
                table: "Portals",
                columns: new[] { "Id", "CurrentLiquidLevel", "Latitude", "LiquidCapacity", "Longitude", "Name", "PortalJunctionId", "Status", "TeleportCount", "TeleportPrice" },
                values: new object[,]
                {
                    { 1, 2.0, 0.0, 3.0, 0.0, "Vilnius", null, 0, 0.0, 0.0 },
                    { 2, 10.0, 1.0, 30.0, 1.0, "Kaunas", null, 2, 0.0, 0.0 },
                    { 3, 20.0, 2.0, 20.0, 2.0, "Klaipeda", null, 1, 0.0, 0.0 },
                    { 4, 20.0, 3.0, 20.0, -3.0, "Panevezys", null, 3, 0.0, 0.0 }
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
                table: "Surveys",
                columns: new[] { "Id", "Description", "EndDate", "StartDate", "Status", "Title" },
                values: new object[] { 1, "Ši apklausa skirta išsiašikinti vienam ir visam kaip žmonės valgo šaltibarščius.", new DateTime(2023, 6, 4, 4, 35, 52, 856, DateTimeKind.Unspecified), new DateTime(2023, 5, 21, 4, 35, 52, 856, DateTimeKind.Unspecified), 0, "Šaltibarščių valgymo ypatumai" });

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
                table: "Complaints",
                columns: new[] { "Id", "Description", "PortalId", "Status", "SubmisionDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Portalas Vilnius yra nepasiekiamas", 1, 0, new DateTime(2023, 5, 4, 4, 35, 52, 856, DateTimeKind.Unspecified), 1 },
                    { 2, "Nu neveikia tas Vilniaus portalas nesamone kazkoke ce", 2, 1, new DateTime(2023, 5, 4, 4, 35, 52, 856, DateTimeKind.Unspecified), 4 },
                    { 3, "Nemoku naudotis portalu padekit", 3, 3, new DateTime(2023, 5, 4, 4, 38, 52, 856, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "RouteVoyages",
                columns: new[] { "Id", "ArrivalId", "DepartureId", "Duration", "Order", "RouteId" },
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

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "Id", "IsRequired", "Order", "Question", "SurveyId", "Type" },
                values: new object[,]
                {
                    { 1, false, 1, "Ar pučiate valgydami šaltibarščius ?", 1, 1 },
                    { 2, false, 2, "Kaip dažnai valgote šaltibarščius ?", 1, 2 },
                    { 3, false, 3, "Kaip galėtumėme pagerinti šią apklausą ?", 1, 0 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintHistories_ComplaintId",
                table: "ComplaintHistories",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_PortalId",
                table: "Complaints",
                column: "PortalId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_UserId",
                table: "Complaints",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalRoutePlace_PlacesId",
                table: "EducationalRoutePlace",
                column: "PlacesId");

            migrationBuilder.CreateIndex(
                name: "IX_Portals_PortalJunctionId",
                table: "Portals",
                column: "PortalJunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_SurveyAnswerId",
                table: "QuestionAnswers",
                column: "SurveyAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_SurveyQuestionId",
                table: "QuestionAnswers",
                column: "SurveyQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswerSurveyQuestionOption_SurveyQuestionOptionsId",
                table: "QuestionAnswerSurveyQuestionOption",
                column: "SurveyQuestionOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteVoyages_ArrivalId",
                table: "RouteVoyages",
                column: "ArrivalId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteVoyages_DepartureId",
                table: "RouteVoyages",
                column: "DepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteVoyages_RouteId",
                table: "RouteVoyages",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswers_SurveyId",
                table: "SurveyAnswers",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionOptions_SurveyQuestionId",
                table: "SurveyQuestionOptions",
                column: "SurveyQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_SurveyId",
                table: "SurveyQuestions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TripId",
                table: "Tickets",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_BusId",
                table: "Trips",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_RouteId",
                table: "Trips",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Voyages_RouteVoyageId",
                table: "Voyages",
                column: "RouteVoyageId");

            migrationBuilder.CreateIndex(
                name: "IX_Voyages_TripId",
                table: "Voyages",
                column: "TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplaintHistories");

            migrationBuilder.DropTable(
                name: "EducationalRoutePlace");

            migrationBuilder.DropTable(
                name: "QuestionAnswerSurveyQuestionOption");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Voyages");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "EducationalRoutes");

            migrationBuilder.DropTable(
                name: "QuestionAnswers");

            migrationBuilder.DropTable(
                name: "SurveyQuestionOptions");

            migrationBuilder.DropTable(
                name: "RouteVoyages");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Portals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SurveyAnswers");

            migrationBuilder.DropTable(
                name: "SurveyQuestions");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "PortalJunctions");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
