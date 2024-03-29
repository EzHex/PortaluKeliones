﻿using Microsoft.EntityFrameworkCore;
using Portalai.Models;
using Route = Portalai.Models.Route;

namespace Portalai;

public class PortalsDbContext : DbContext
{
    public PortalsDbContext(DbContextOptions options) : base(options)
    {
    }

    public PortalsDbContext()
    {
    }

    public virtual DbSet<User> Users { get; set; } = null!;

    public virtual DbSet<Place> Places { get; set; } = null!;

    public virtual DbSet<Portal> Portals { get; set; } = null!;

    public virtual DbSet<PortalJunction> PortalJunctions { get; set; } = null!;

    public virtual DbSet<Route> Routes { get; set; } = null!;

    public virtual DbSet<RouteVoyage> RouteVoyages { get; set; } = null!;

    public virtual DbSet<Ticket> Tickets { get; set; } = null!;

    public virtual DbSet<Trip> Trips { get; set; } = null!;

    public virtual DbSet<Voyage> Voyages { get; set; } = null!;

    public virtual DbSet<Bus> Buses { get; set; } = null!;

    public virtual DbSet<Complaint> Complaints { get; set; } = null!;

    public virtual DbSet<ComplaintHistory> ComplaintHistories { get; set; } = null!;

    public virtual DbSet<EducationalRoute> EducationalRoutes { get; set; } = null!;

    public virtual DbSet<Survey> Surveys { get; set; } = null!;

    public virtual DbSet<SurveyAnswer> SurveyAnswers { get; set; } = null!;

    public virtual DbSet<SurveyQuestion> SurveyQuestions { get; set; } = null!;

    public virtual DbSet<SurveyQuestionOption> SurveyQuestionOptions { get; set; } = null!;

    public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var places = new[]
        {
            new Place(1, "Vilnius", 54.6872, 25.28),
            new Place(2, "Kaunas", 54.8972, 23.8861),
            new Place(3, "Klaipeda", 55.75, 21.1667),
            new Place(4, "Panevezys", 55.7333, 24.35),
            new Place(5, "Siauliai", 55.9333, 23.3167),
            new Place(6, "Alytus", 54.4014, 24.0492),
            new Place(7, "Marijampole", 54.5472, 23.35),
            new Place(8, "Mazeikiai", 56.3167, 22.3333),
            new Place(9, "Jonava", 55.0722, 24.2806),
            new Place(10, "Utena", 55.5, 25.6),
            new Place(11, "Kedainiai", 55.2833, 23.9667),
            new Place(12, "Telsiai", 55.9833, 22.25),
            new Place(13, "Taurage", 55.2522, 22.2897),
            new Place(14, "Ukmerge", 55.25, 24.75),
            new Place(15, "Visaginas", 55.598, 26.438),
            new Place(16, "Palanga", 55.9167, 21.0667),
            new Place(17, "Plunge", 55.9167, 21.85),
            new Place(18, "Kretinga", 55.89, 21.2422),
            new Place(19, "Silute", 55.35, 21.4833),
            new Place(20, "Radviliskis", 55.8, 23.55),
            new Place(21, "Druskininkai", 54.0167, 23.9667),
            new Place(22, "Rokiskis", 55.9667, 25.5833),
            new Place(23, "Elektrenai", 54.7861, 24.6611),
            new Place(24, "Jurbarkas", 55.0833, 22.7667),
            new Place(25, "Birzai", 56.2, 24.75),
            new Place(26, "Vilkaviskis", 54.65, 23.0333),
            new Place(27, "Raseiniai", 55.3667, 23.1167),
            new Place(28, "Prienai", 54.6333, 23.9417),
            new Place(29, "Joniskis", 56.2333, 23.6),
            new Place(30, "Anyksciai", 55.5333, 25.1),
            new Place(31, "Varena", 54.2111, 24.5722),
            new Place(32, "Kaisiadorys", 54.8667, 24.45),
            new Place(33, "Naujoji Akmene", 56.3167, 22.9),
            new Place(34, "Kelme", 55.6333, 22.9333),
            new Place(35, "Salcininkai", 54.3167, 25.3833),
            new Place(36, "Pasvalys", 56.0594, 24.4036),
            new Place(37, "Kupiskis", 55.8333, 24.9667),
            new Place(38, "Zarasai", 55.7333, 26.25),
            new Place(39, "Trakai", 54.6333, 24.9333),
            new Place(40, "Moletai", 55.2333, 25.4167),
            new Place(41, "Kazlu Ruda", 54.75, 23.5),
            new Place(42, "Sakiai", 54.95, 23.05),
            new Place(43, "Skuodas", 56.2667, 21.5333),
            new Place(44, "Ignalina", 55.35, 26.1667),
            new Place(45, "Silale", 55.4833, 22.1833),
            new Place(46, "Pakruojis", 55.9667, 23.8667),
            new Place(47, "Svencionys", 55.1333, 26.1556),
            new Place(48, "Kalvarija", 54.4167, 23.2167),
            new Place(49, "Lazdijai", 54.2333, 23.5167),
            new Place(50, "Rietavas", 55.7167, 21.9333),
            new Place(51, "Birstonas", 54.6028, 24.0206),
            new Place(52, "Nida", 55.3033, 21.0056),
            new Place(53, "Sirvintos", 55.0361, 24.9694),
            new Place(54, "Pagegiai", 55.1333, 21.9167),
            new Place(55, "Gargzdai", 55.7128, 21.4033),
            new Place(56, "Aukstieji Paneriai", 54.6, 25.2),
            new Place(57, "Grigiskes", 54.6667, 25.1),
            new Place(58, "Kursenai", 55.9833, 22.9167),
            new Place(59, "Likiskiai", 54.395, 23.997),
            new Place(60, "Garliava", 54.8167, 23.8667),
            new Place(61, "Lentvaris", 54.65, 25.0667)
        };

        modelBuilder.Entity<Place>().HasData(places);

        var routes = new[]
        {
            new Route { Id = 1, Title = "Zarasai - Rokiškis - Panevėžys - Šiauliai - Plungė - Palanga - Klaipėda" },
            new Route { Id = 2, Title = "Vilnius - Kaunas - Raseiniai - Kryžkalnis - Klaipėda" },
            new Route { Id = 3, Title = "Rokiškis - Anykščiai - Ukmergė - Jonava - Kaunas" }
        };

        modelBuilder.Entity<Route>().HasData(routes);

        var routeVoyages = new[]
        {
            //ROUTE3
            new RouteVoyage
            {
                Id = 1, Order = 1, Duration = 70, ArrivalId = places[29].Id, DepartureId = places[21].Id,
                RouteId = routes[2].Id
            },
            new RouteVoyage
            {
                Id = 2, Order = 2, Duration = 50, ArrivalId = places[13].Id, DepartureId = places[29].Id,
                RouteId = routes[2].Id
            },
            new RouteVoyage
            {
                Id = 3, Order = 3, Duration = 40, ArrivalId = places[8].Id, DepartureId = places[13].Id,
                RouteId = routes[2].Id
            },
            new RouteVoyage
            {
                Id = 4, Order = 4, Duration = 45, ArrivalId = places[2].Id, DepartureId = places[8].Id,
                RouteId = routes[2].Id
            },
            //ROUTE2
            new RouteVoyage
            {
                Id = 5, Order = 1, Duration = 105, ArrivalId = places[1].Id, DepartureId = places[0].Id,
                RouteId = routes[1].Id
            },
            new RouteVoyage
            {
                Id = 6, Order = 2, Duration = 90, ArrivalId = places[26].Id, DepartureId = places[1].Id,
                RouteId = routes[1].Id
            },
            new RouteVoyage
            {
                Id = 7, Order = 3, Duration = 150, ArrivalId = places[2].Id, DepartureId = places[26].Id,
                RouteId = routes[1].Id
            },
            //ROUTE1 "Zarasai - Rokiškis - Panevėžys - Šiauliai - Plungė - Palanga - Klaipėda"
            new RouteVoyage
            {
                Id = 8, Order = 1, Duration = 90, ArrivalId = places[21].Id, DepartureId = places[37].Id,
                RouteId = routes[0].Id
            },
            new RouteVoyage
            {
                Id = 9, Order = 2, Duration = 120, ArrivalId = places[3].Id, DepartureId = places[21].Id,
                RouteId = routes[0].Id
            },
            new RouteVoyage
            {
                Id = 10, Order = 3, Duration = 120, ArrivalId = places[4].Id, DepartureId = places[3].Id,
                RouteId = routes[0].Id
            },
            new RouteVoyage
            {
                Id = 11, Order = 4, Duration = 120, ArrivalId = places[16].Id, DepartureId = places[4].Id,
                RouteId = routes[0].Id
            },
            new RouteVoyage
            {
                Id = 12, Order = 5, Duration = 65, ArrivalId = places[15].Id, DepartureId = places[16].Id,
                RouteId = routes[0].Id
            },
            new RouteVoyage
            {
                Id = 13, Order = 6, Duration = 30, ArrivalId = places[2].Id, DepartureId = places[15].Id,
                RouteId = routes[0].Id
            }
        };

        modelBuilder.Entity<RouteVoyage>().HasData(routeVoyages);

        var buses = new[]
        {
            new Bus
            {
                Id = 1, LicensePlate = "ABC 123", Brand = "Opel", Model = "Vivado",
                ManufactureDate = Convert.ToDateTime("2023-05-22").AddYears(-5), Fuel = FuelTypes.Diesel, Seats = 42,
                Status = BusStatus.Garage
            },
            new Bus
            {
                Id = 2, LicensePlate = "BCA 234", Brand = "Opel", Model = "Vivado",
                ManufactureDate = Convert.ToDateTime("2023-05-22").AddYears(-2), Fuel = FuelTypes.Petrol, Seats = 54,
                Status = BusStatus.Garage
            },
            new Bus
            {
                Id = 3, LicensePlate = "CDE 345", Brand = "Arnas", Model = "Gaming",
                ManufactureDate = Convert.ToDateTime("2023-05-22").AddYears(-7), Fuel = FuelTypes.PetrolElectricity,
                Seats = 12,
                Status = BusStatus.Garage
            },
            new Bus
            {
                Id = 4, LicensePlate = "DEF 456", Brand = "Arnas", Model = "Driving",
                ManufactureDate = Convert.ToDateTime("2023-05-22").AddYears(-12), Fuel = FuelTypes.Electricity,
                Seats = 34,
                Status = BusStatus.Garage
            },
            new Bus
            {
                Id = 5, LicensePlate = "EFG 567", Brand = "Mad Lions", Model = "Base",
                ManufactureDate = Convert.ToDateTime("2023-05-22").AddYears(-14), Fuel = FuelTypes.PetrolElectricity,
                Seats = 57,
                Status = BusStatus.Garage
            },
            new Bus
            {
                Id = 6, LicensePlate = "FGH 678", Brand = "Mad Lions", Model = "Express",
                ManufactureDate = Convert.ToDateTime("2023-05-22").AddYears(-8), Fuel = FuelTypes.Electricity,
                Seats = 86,
                Status = BusStatus.Garage
            },
            new Bus
            {
                Id = 7, LicensePlate = "GHI 789", Brand = "Mode", Model = "Driving",
                ManufactureDate = Convert.ToDateTime("2023-05-22").AddYears(-6), Fuel = FuelTypes.Petrol, Seats = 56,
                Status = BusStatus.Garage
            },
            new Bus
            {
                Id = 8, LicensePlate = "JKL 890", Brand = "Mode", Model = "Trolling",
                ManufactureDate = Convert.ToDateTime("2023-05-22").AddYears(-5), Fuel = FuelTypes.Petrol, Seats = 21,
                Status = BusStatus.Garage
            }
        };

        modelBuilder.Entity<Bus>().HasData(buses);

        var users = new[]
        {
            new User
            {
                Id = 1, Name = "Arnas", Email = "Arnas@PortalsDB.com", Password = "UUID", Role = Roles.Fixer,
                Phone = "860000000"
            },
            new User
            {
                Id = 2, Name = "Modestas", Email = "Modestas@PortalsDB.com", Password = "UUID",
                Role = Roles.Administrator, Phone = "860000000"
            },
            new User
            {
                Id = 3, Name = "Viktorija", Email = "Viktorija@PortalsDB.com", Password = "UUID", Role = Roles.Client,
                Phone = "860000000"
            },
            new User
            {
                Id = 4, Name = "Dominykas", Email = "Dominykas@PortalsDB.com", Password = "UUID", Role = Roles.Driver,
                Phone = "860000000"
            },
            new User
            {
                Id = 5, Name = "Karolis", Email = "Karolis@PortalsDB.com", Password = "UUID",
                Role = Roles.Administrator, Phone = "860000000"
            }
        };

        modelBuilder.Entity<User>().HasData(users);

        var survey = new Survey
        {
            Description = "Ši apklausa skirta išsiašikinti vienam ir visam kaip žmonės valgo šaltibarščius.",
            StartDate = Convert.ToDateTime("2023-05-21 04:35:52.8560000"),
            EndDate = Convert.ToDateTime("2023-06-04 04:35:52.8560000"),
            Title = "Šaltibarščių valgymo ypatumai",
            Status = 0,
            Id = 1
        };

        modelBuilder.Entity<Survey>().HasData(survey);

        var surveyQuestions = new[]
        {
            new SurveyQuestion
            {
                Id = 1,
                SurveyId = survey.Id,
                Question = "Ar pučiate valgydami šaltibarščius ?",
                Type = QuestionType.SingleChoice,
                Order = 1
            },
            new SurveyQuestion
            {
                Id = 2,
                SurveyId = survey.Id,
                Question = "Kaip dažnai valgote šaltibarščius ?",
                Type = QuestionType.MultipleChoice,
                Order = 2
            },
            new SurveyQuestion
            {
                Id = 3,
                SurveyId = survey.Id,
                Question = "Kaip galėtumėme pagerinti šią apklausą ?",
                Type = QuestionType.Open,
                Order = 3
            },
        };

        modelBuilder.Entity<SurveyQuestion>().HasData(surveyQuestions);

        var surveyQuestionOptions = new[]
        {
            new SurveyQuestionOption
            {
                Id = 1,
                SurveyQuestionId = surveyQuestions[0].Id,
                Text = "Taip"
            },
            new SurveyQuestionOption
            {
                Id = 2,
                SurveyQuestionId = surveyQuestions[0].Id,
                Text = "Ne"
            },
            new SurveyQuestionOption
            {
                Id = 3,
                SurveyQuestionId = surveyQuestions[1].Id,
                Text = "Nevalgau"
            },
            new SurveyQuestionOption
            {
                Id = 4,
                SurveyQuestionId = surveyQuestions[1].Id,
                Text = "Kartą į metus"
            },
            new SurveyQuestionOption
            {
                Id = 5,
                SurveyQuestionId = surveyQuestions[1].Id,
                Text = "Retai"
            },
            new SurveyQuestionOption
            {
                Id = 6,
                SurveyQuestionId = surveyQuestions[1].Id,
                Text = "Vasarą"
            },
            new SurveyQuestionOption
            {
                Id = 7,
                SurveyQuestionId = surveyQuestions[1].Id,
                Text = "Šaltibarščiai tai mano gyvenimas"
            },
        };

        modelBuilder.Entity<SurveyQuestionOption>().HasData(surveyQuestionOptions);

        //Add portals to context
        var portals = new[]
        {
            new Portal
            {
                Id = 1,
                Name = "Vilnius",
                Longitude = 0,
                Latitude = 0,
                CurrentLiquidLevel = 2,
                LiquidCapacity = 3,
                Status = PortalStatus.NotWorking
            },
            new Portal
            {
                Id = 2,
                Name = "Kaunas",
                Longitude = 1,
                Latitude = 1,
                CurrentLiquidLevel = 10,
                LiquidCapacity = 30,
                Status = PortalStatus.InMaintenance
            },
            new Portal
            {
                Id = 3,
                Name = "Klaipeda",
                Longitude = 2,
                Latitude = 2,
                CurrentLiquidLevel = 20,
                LiquidCapacity = 20,
                Status = PortalStatus.Working
            },
            new Portal
            {
                Id = 4,
                Name = "Panevezys",
                Longitude = -3,
                Latitude = 3,
                CurrentLiquidLevel = 20,
                LiquidCapacity = 20,
                Status = PortalStatus.Reserved
            }
        };

        modelBuilder.Entity<Portal>().HasData(portals);

        //Create complaint

        var complaints = new[]
        {
            new Complaint
            {
                Id = 1,
                SubmisionDate = Convert.ToDateTime("2023-05-04 04:35:52.8560000"),
                Description = "Portalas Vilnius yra nepasiekiamas",
                Status = ComplaintStatus.Submited,
                PortalId = portals[0].Id,
                UserId = users[0].Id,
            },
            new Complaint
            {
                Id = 2,
                SubmisionDate = Convert.ToDateTime("2023-05-04 04:35:52.8560000"),
                Description = "Nu neveikia tas Vilniaus portalas nesamone kazkoke ce",
                Status = ComplaintStatus.InProgress,
                PortalId = portals[1].Id,
                UserId = users[3].Id,
            },
            new Complaint
            {
                Id = 3,
                SubmisionDate = Convert.ToDateTime("2023-05-04 04:38:52.8560000"),
                Description = "Nemoku naudotis portalu padekit",
                Status = ComplaintStatus.Rejected,
                PortalId = portals[2].Id,
                UserId = users[0].Id,
            },
        };

        modelBuilder.Entity<Complaint>().HasData(complaints);

        //Create complaint history
        var complaintHistories = new[]
        {
            new ComplaintHistory
            {
                Id = 1,
                Date = Convert.ToDateTime("2023-05-04 04:35:52.8560000"),
                Status = ComplaintStatus.Submited,
                Comment = "Portalas Vilnius yra nepasiekiamas",
                ComplaintId = complaints[0].Id
            },
            new ComplaintHistory
            {
                Id = 2,
                Date = Convert.ToDateTime("2023-05-04 07:35:52.8560000"),
                Status = ComplaintStatus.Submited,
                Comment = "Portalas Vilnius yra nepasiekiamas",
                ComplaintId = complaints[1].Id
            },
            new ComplaintHistory
            {
                Id = 3,
                Date = Convert.ToDateTime("2023-05-04 08:35:52.8560000"),
                Status = ComplaintStatus.InProgress,
                Comment = "Aptiktas ortalo skysčio lygio trūkumas. Problema pradėta spręsti",
                ComplaintId = complaints[1].Id
            },
            new ComplaintHistory
            {
                Id = 4,
                Date = Convert.ToDateTime("2023-05-04 06:35:52.8560000"),
                Status = ComplaintStatus.Submited,
                Comment = "Nemoku naudotis portalu padekit",
                ComplaintId = complaints[2].Id
            },
            new ComplaintHistory
            {
                Id = 5,
                Date = Convert.ToDateTime("2023-05-04 06:35:52.8560000"),
                Status = ComplaintStatus.Rejected,
                Comment = "Klaidingas pranešimas, portalas veikia",
                ComplaintId = complaints[2].Id
            },
        };
        
        //save histories
        modelBuilder.Entity<ComplaintHistory>().HasData(complaintHistories);
    }
}