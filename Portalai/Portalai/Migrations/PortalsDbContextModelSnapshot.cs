﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Portalai.Migrations
{
    [DbContext(typeof(PortalsDbContext))]
    partial class PortalsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EducationalRoutePlace", b =>
                {
                    b.Property<int>("EducationalRoutesId")
                        .HasColumnType("int");

                    b.Property<int>("PlacesId")
                        .HasColumnType("int");

                    b.HasKey("EducationalRoutesId", "PlacesId");

                    b.HasIndex("PlacesId");

                    b.ToTable("EducationalRoutePlace");
                });

            modelBuilder.Entity("PlaceRouteVoyage", b =>
                {
                    b.Property<int>("PlacesId")
                        .HasColumnType("int");

                    b.Property<int>("RouteVoyagesId")
                        .HasColumnType("int");

                    b.HasKey("PlacesId", "RouteVoyagesId");

                    b.HasIndex("RouteVoyagesId");

                    b.ToTable("PlaceRouteVoyage");
                });

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

                    b.HasKey("Id");

                    b.HasIndex("PortalId");

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

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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

                    b.Property<int>("PortalJunctionId")
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

                    b.Property<int>("SurveyQuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

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

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Portalai.Models.RouteVoyage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("RoutesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoutesId");

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

                    b.Property<int?>("QuestionAnswerId")
                        .HasColumnType("int");

                    b.Property<int>("SurveyQuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionAnswerId");

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

                    b.HasKey("Id");

                    b.HasIndex("BusId");

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

                    b.HasKey("Id");

                    b.HasIndex("RouteVoyageId");

                    b.ToTable("Voyages");
                });

            modelBuilder.Entity("EducationalRoutePlace", b =>
                {
                    b.HasOne("Portalai.Models.EducationalRoute", null)
                        .WithMany()
                        .HasForeignKey("EducationalRoutesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portalai.Models.Place", null)
                        .WithMany()
                        .HasForeignKey("PlacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlaceRouteVoyage", b =>
                {
                    b.HasOne("Portalai.Models.Place", null)
                        .WithMany()
                        .HasForeignKey("PlacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portalai.Models.RouteVoyage", null)
                        .WithMany()
                        .HasForeignKey("RouteVoyagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portalai.Models.Complaint", b =>
                {
                    b.HasOne("Portalai.Models.Portal", "Portal")
                        .WithMany("Complaints")
                        .HasForeignKey("PortalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portal");
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

            modelBuilder.Entity("Portalai.Models.Portal", b =>
                {
                    b.HasOne("Portalai.Models.PortalJunction", "PortalJunction")
                        .WithMany("Portals")
                        .HasForeignKey("PortalJunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PortalJunction");
                });

            modelBuilder.Entity("Portalai.Models.QuestionAnswer", b =>
                {
                    b.HasOne("Portalai.Models.SurveyQuestion", "SurveyQuestion")
                        .WithMany()
                        .HasForeignKey("SurveyQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SurveyQuestion");
                });

            modelBuilder.Entity("Portalai.Models.Route", b =>
                {
                    b.HasOne("Portalai.Models.Trip", "Trip")
                        .WithMany("Routes")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Portalai.Models.RouteVoyage", b =>
                {
                    b.HasOne("Portalai.Models.Route", "Routes")
                        .WithMany("RouteVoyages")
                        .HasForeignKey("RoutesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Routes");
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
                    b.HasOne("Portalai.Models.QuestionAnswer", null)
                        .WithMany("SurveyQuestionOptions")
                        .HasForeignKey("QuestionAnswerId");

                    b.HasOne("Portalai.Models.SurveyQuestion", "SurveyQuestion")
                        .WithMany()
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

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("Portalai.Models.Voyage", b =>
                {
                    b.HasOne("Portalai.Models.RouteVoyage", "RouteVoyage")
                        .WithMany("Voyage")
                        .HasForeignKey("RouteVoyageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RouteVoyage");
                });

            modelBuilder.Entity("Portalai.Models.Bus", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("Portalai.Models.Complaint", b =>
                {
                    b.Navigation("ComplaintHistories");
                });

            modelBuilder.Entity("Portalai.Models.Portal", b =>
                {
                    b.Navigation("Complaints");
                });

            modelBuilder.Entity("Portalai.Models.PortalJunction", b =>
                {
                    b.Navigation("Portals");
                });

            modelBuilder.Entity("Portalai.Models.QuestionAnswer", b =>
                {
                    b.Navigation("SurveyQuestionOptions");
                });

            modelBuilder.Entity("Portalai.Models.Route", b =>
                {
                    b.Navigation("RouteVoyages");
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

            modelBuilder.Entity("Portalai.Models.Trip", b =>
                {
                    b.Navigation("Routes");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Portalai.Models.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
