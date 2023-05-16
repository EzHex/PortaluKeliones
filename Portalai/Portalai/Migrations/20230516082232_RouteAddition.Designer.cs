﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Portalai.Migrations
{
    [DbContext(typeof(PortalsDbContext))]
    [Migration("20230516082232_RouteAddition")]
    partial class RouteAddition
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Portalai.Models.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fuel")
                        .HasColumnType("int");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ManufactureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("Portalai.Models.Complaint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PortalId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmisionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PortalId");

                    b.HasIndex("UserId");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("Portalai.Models.ComplaintHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ComplaintId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComplaintId");

                    b.ToTable("ComplaintHistories");
                });

            modelBuilder.Entity("Portalai.Models.EducationalRoute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("RatingCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EducationalRoutes");
                });

            modelBuilder.Entity("Portalai.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("EducationalRouteId")
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EducationalRouteId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Portalai.Models.Portal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("CurrentLiquidLevel")
                        .HasColumnType("float");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("LiquidCapacity")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<int?>("PortalJunctionId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("TeleportCount")
                        .HasColumnType("float");

                    b.Property<double>("TeleportPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PortalJunctionId");

                    b.ToTable("Portals");
                });

            modelBuilder.Entity("Portalai.Models.PortalJunction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("PortalJunctions");
                });

            modelBuilder.Entity("Portalai.Models.QuestionAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SurveyAnswerId")
                        .HasColumnType("int");

                    b.Property<int>("SurveyQuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SurveyAnswerId");

                    b.HasIndex("SurveyQuestionId");

                    b.ToTable("QuestionAnswers");
                });

            modelBuilder.Entity("Portalai.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Portalai.Models.RouteVoyage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArrivalPlaceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeparturePlaceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArrivalPlaceId");

                    b.HasIndex("DeparturePlaceId");

                    b.HasIndex("RouteId");

                    b.ToTable("RouteVoyages");
                });

            modelBuilder.Entity("Portalai.Models.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("Portalai.Models.SurveyAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AnswerDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SurveyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("SurveyAnswers");
                });

            modelBuilder.Entity("Portalai.Models.SurveyQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SurveyId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("SurveyQuestions");
                });

            modelBuilder.Entity("Portalai.Models.SurveyQuestionOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("SurveyQuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SurveyQuestionId");

                    b.ToTable("SurveyQuestionOptions");
                });

            modelBuilder.Entity("Portalai.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Seat")
                        .HasColumnType("int");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Portalai.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.HasIndex("RouteId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Portalai.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Portalai.Models.Voyage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RouteVoyageId")
                        .HasColumnType("int");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RouteVoyageId");

                    b.HasIndex("TripId");

                    b.ToTable("Voyages");
                });

            modelBuilder.Entity("QuestionAnswerSurveyQuestionOption", b =>
                {
                    b.Property<int>("QuestionAnswersId")
                        .HasColumnType("int");

                    b.Property<int>("SurveyQuestionOptionsId")
                        .HasColumnType("int");

                    b.HasKey("QuestionAnswersId", "SurveyQuestionOptionsId");

                    b.HasIndex("SurveyQuestionOptionsId");

                    b.ToTable("QuestionAnswerSurveyQuestionOption");
                });

            modelBuilder.Entity("Portalai.Models.Complaint", b =>
                {
                    b.HasOne("Portalai.Models.Portal", "Portal")
                        .WithMany("Complaints")
                        .HasForeignKey("PortalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portalai.Models.User", "User")
                        .WithMany("Complaints")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Portalai.Models.ComplaintHistory", b =>
                {
                    b.HasOne("Portalai.Models.Complaint", "Complaint")
                        .WithMany("ComplaintHistories")
                        .HasForeignKey("ComplaintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Complaint");
                });

            modelBuilder.Entity("Portalai.Models.Place", b =>
                {
                    b.HasOne("Portalai.Models.EducationalRoute", null)
                        .WithMany("Places")
                        .HasForeignKey("EducationalRouteId");
                });

            modelBuilder.Entity("Portalai.Models.Portal", b =>
                {
                    b.HasOne("Portalai.Models.PortalJunction", "PortalJunction")
                        .WithMany("Portals")
                        .HasForeignKey("PortalJunctionId");

                    b.Navigation("PortalJunction");
                });

            modelBuilder.Entity("Portalai.Models.QuestionAnswer", b =>
                {
                    b.HasOne("Portalai.Models.SurveyAnswer", "SurveyAnswer")
                        .WithMany("QuestionAnswers")
                        .HasForeignKey("SurveyAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portalai.Models.SurveyQuestion", "SurveyQuestion")
                        .WithMany("QuestionAnswers")
                        .HasForeignKey("SurveyQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SurveyAnswer");

                    b.Navigation("SurveyQuestion");
                });

            modelBuilder.Entity("Portalai.Models.RouteVoyage", b =>
                {
                    b.HasOne("Portalai.Models.Place", "Arrival")
                        .WithMany("ArrivalVoyages")
                        .HasForeignKey("ArrivalPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portalai.Models.Place", "Departure")
                        .WithMany("DepartureVoyages")
                        .HasForeignKey("DeparturePlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portalai.Models.Route", "Route")
                        .WithMany("RouteVoyages")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arrival");

                    b.Navigation("Departure");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Portalai.Models.SurveyAnswer", b =>
                {
                    b.HasOne("Portalai.Models.Survey", "Survey")
                        .WithMany("SurveyAnswers")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("Portalai.Models.SurveyQuestion", b =>
                {
                    b.HasOne("Portalai.Models.Survey", "Survey")
                        .WithMany("SurveyQuestions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("Portalai.Models.SurveyQuestionOption", b =>
                {
                    b.HasOne("Portalai.Models.SurveyQuestion", "SurveyQuestion")
                        .WithMany("SurveyQuestionOptions")
                        .HasForeignKey("SurveyQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SurveyQuestion");
                });

            modelBuilder.Entity("Portalai.Models.Ticket", b =>
                {
                    b.HasOne("Portalai.Models.Trip", "Trip")
                        .WithMany("Tickets")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portalai.Models.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Portalai.Models.Trip", b =>
                {
                    b.HasOne("Portalai.Models.Bus", "Bus")
                        .WithMany("Trips")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portalai.Models.Route", "Route")
                        .WithMany("Trips")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Portalai.Models.Voyage", b =>
                {
                    b.HasOne("Portalai.Models.RouteVoyage", "RouteVoyage")
                        .WithMany("Voyage")
                        .HasForeignKey("RouteVoyageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portalai.Models.Trip", "Trip")
                        .WithMany("Voyages")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RouteVoyage");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("QuestionAnswerSurveyQuestionOption", b =>
                {
                    b.HasOne("Portalai.Models.QuestionAnswer", null)
                        .WithMany()
                        .HasForeignKey("QuestionAnswersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portalai.Models.SurveyQuestionOption", null)
                        .WithMany()
                        .HasForeignKey("SurveyQuestionOptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portalai.Models.Bus", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("Portalai.Models.Complaint", b =>
                {
                    b.Navigation("ComplaintHistories");
                });

            modelBuilder.Entity("Portalai.Models.EducationalRoute", b =>
                {
                    b.Navigation("Places");
                });

            modelBuilder.Entity("Portalai.Models.Place", b =>
                {
                    b.Navigation("ArrivalVoyages");

                    b.Navigation("DepartureVoyages");
                });

            modelBuilder.Entity("Portalai.Models.Portal", b =>
                {
                    b.Navigation("Complaints");
                });

            modelBuilder.Entity("Portalai.Models.PortalJunction", b =>
                {
                    b.Navigation("Portals");
                });

            modelBuilder.Entity("Portalai.Models.Route", b =>
                {
                    b.Navigation("RouteVoyages");

                    b.Navigation("Trips");
                });

            modelBuilder.Entity("Portalai.Models.RouteVoyage", b =>
                {
                    b.Navigation("Voyage");
                });

            modelBuilder.Entity("Portalai.Models.Survey", b =>
                {
                    b.Navigation("SurveyAnswers");

                    b.Navigation("SurveyQuestions");
                });

            modelBuilder.Entity("Portalai.Models.SurveyAnswer", b =>
                {
                    b.Navigation("QuestionAnswers");
                });

            modelBuilder.Entity("Portalai.Models.SurveyQuestion", b =>
                {
                    b.Navigation("QuestionAnswers");

                    b.Navigation("SurveyQuestionOptions");
                });

            modelBuilder.Entity("Portalai.Models.Trip", b =>
                {
                    b.Navigation("Tickets");

                    b.Navigation("Voyages");
                });

            modelBuilder.Entity("Portalai.Models.User", b =>
                {
                    b.Navigation("Complaints");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
