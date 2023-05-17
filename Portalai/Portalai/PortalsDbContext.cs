using Microsoft.EntityFrameworkCore;
using Portalai.Models;
using Route = Portalai.Models.Route;

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

        var places = new [] {
            new Place(1,"Vilnius", 54.6872, 25.28),
            new Place(2,"Kaunas", 54.8972, 23.8861),
            new Place(3,"Klaipeda", 55.75, 21.1667),
            new Place(4,"Panevezys", 55.7333, 24.35),
            new Place(5,"Siauliai", 55.9333, 23.3167),
            new Place(6,"Alytus", 54.4014, 24.0492),
            new Place(7,"Marijampole", 54.5472, 23.35),
            new Place(8,"Mazeikiai", 56.3167, 22.3333),
            new Place(9,"Jonava", 55.0722, 24.2806),
            new Place(10,"Utena", 55.5, 25.6),
            new Place(11,"Kedainiai", 55.2833, 23.9667),
            new Place(12,"Telsiai", 55.9833, 22.25),
            new Place(13,"Taurage", 55.2522, 22.2897),
            new Place(14,"Ukmerge", 55.25, 24.75),
            new Place(15,"Visaginas", 55.598, 26.438),
            new Place(16,"Palanga", 55.9167, 21.0667),
            new Place(17,"Plunge", 55.9167, 21.85),
            new Place(18,"Kretinga", 55.89, 21.2422),
            new Place(19,"Silute", 55.35, 21.4833),
            new Place(20,"Radviliskis", 55.8, 23.55),
            new Place(21,"Druskininkai", 54.0167, 23.9667),
            new Place(22,"Rokiskis", 55.9667, 25.5833),
            new Place(23,"Elektrenai", 54.7861, 24.6611),
            new Place(24,"Jurbarkas", 55.0833, 22.7667),
            new Place(25,"Birzai", 56.2, 24.75),
            new Place(26,"Vilkaviskis", 54.65, 23.0333),
            new Place(27,"Raseiniai", 55.3667, 23.1167),
            new Place(28,"Prienai", 54.6333, 23.9417),
            new Place(29,"Joniskis", 56.2333, 23.6),
            new Place(30,"Anyksciai", 55.5333, 25.1),
            new Place(31,"Varena", 54.2111, 24.5722),
            new Place(32,"Kaisiadorys", 54.8667, 24.45),
            new Place(33,"Naujoji Akmene", 56.3167, 22.9),
            new Place(34,"Kelme", 55.6333, 22.9333),
            new Place(35,"Salcininkai", 54.3167, 25.3833),
            new Place(36,"Pasvalys", 56.0594, 24.4036),
            new Place(37,"Kupiskis", 55.8333, 24.9667),
            new Place(38,"Zarasai", 55.7333, 26.25),
            new Place(39,"Trakai", 54.6333, 24.9333),
            new Place(40,"Moletai", 55.2333, 25.4167),
            new Place(41,"Kazlu Ruda", 54.75, 23.5),
            new Place(42,"Sakiai", 54.95, 23.05),
            new Place(43,"Skuodas", 56.2667, 21.5333),
            new Place(44,"Ignalina", 55.35, 26.1667),
            new Place(45,"Silale", 55.4833, 22.1833),
            new Place(46,"Pakruojis", 55.9667, 23.8667),
            new Place(47,"Svencionys", 55.1333, 26.1556),
            new Place(48,"Kalvarija", 54.4167, 23.2167),
            new Place(49,"Lazdijai", 54.2333, 23.5167),
            new Place(50,"Rietavas", 55.7167, 21.9333),
            new Place(51,"Birstonas", 54.6028, 24.0206),
            new Place(52,"Nida", 55.3033, 21.0056),
            new Place(53,"Sirvintos", 55.0361, 24.9694),
            new Place(54,"Pagegiai", 55.1333, 21.9167),
            new Place(55,"Gargzdai", 55.7128, 21.4033),
            new Place(56,"Aukstieji Paneriai", 54.6, 25.2),
            new Place(57,"Grigiskes", 54.6667, 25.1),
            new Place(58,"Kursenai", 55.9833, 22.9167),
            new Place(59,"Likiskiai", 54.395, 23.997),
            new Place(60,"Garliava", 54.8167, 23.8667),
            new Place(61,"Lentvaris", 54.65, 25.0667)
        };
        
        modelBuilder.Entity<Place>().HasData(places);

        var routes = new[]
        {
            new Route(1, "Zarasai - Rokiškis - Panevėžys - Šiauliai - Plungė - Palanga - Klaipėda"),
            new Route(2, "Vilnius - Kaunas - Raseiniai - Kryžkalnis - Klaipėda"),
            new Route(3, "Rokiškis - Anykščiai - Ukmergė - Jonava - Kaunas")
        };
        
        modelBuilder.Entity<Route>().HasData(routes);

        var routeVoyages = new[]
        {
            //ROUTE3
            new RouteVoyage
            { Id = 1,Order = 1, Duration = 70, ArrivalPlaceId = places[29].Id, DeparturePlaceId = places[21].Id, RouteId = routes[2].Id },
            new RouteVoyage
            { Id = 2,Order = 2, Duration = 50, ArrivalPlaceId = places[13].Id, DeparturePlaceId = places[29].Id, RouteId = routes[2].Id },
            new RouteVoyage
            { Id = 3,Order = 3, Duration = 40, ArrivalPlaceId = places[8].Id, DeparturePlaceId = places[13].Id, RouteId = routes[2].Id },
            new RouteVoyage
            { Id = 4,Order = 4, Duration = 45, ArrivalPlaceId = places[2].Id, DeparturePlaceId = places[8].Id, RouteId = routes[2].Id },
            //ROUTE2
            new RouteVoyage
                { Id = 5,Order = 1, Duration = 105, ArrivalPlaceId = places[1].Id, DeparturePlaceId = places[0].Id, RouteId = routes[1].Id },
            new RouteVoyage
                { Id = 6,Order = 2, Duration = 90, ArrivalPlaceId = places[26].Id, DeparturePlaceId = places[1].Id, RouteId = routes[1].Id },
            new RouteVoyage
                { Id = 7,Order = 3, Duration = 150, ArrivalPlaceId = places[2].Id, DeparturePlaceId = places[26].Id, RouteId = routes[1].Id },
            //ROUTE1 "Zarasai - Rokiškis - Panevėžys - Šiauliai - Plungė - Palanga - Klaipėda"
            new RouteVoyage
                { Id = 8,Order = 1, Duration = 90, ArrivalPlaceId = places[21].Id, DeparturePlaceId = places[37].Id, RouteId = routes[0].Id },
            new RouteVoyage
                { Id = 9,Order = 2, Duration = 120, ArrivalPlaceId = places[3].Id, DeparturePlaceId = places[21].Id, RouteId = routes[0].Id },
            new RouteVoyage
                { Id = 10,Order = 3, Duration = 120, ArrivalPlaceId = places[4].Id, DeparturePlaceId = places[3].Id, RouteId = routes[0].Id },
            new RouteVoyage
                { Id = 11,Order = 4, Duration = 120, ArrivalPlaceId = places[16].Id, DeparturePlaceId = places[4].Id, RouteId = routes[0].Id },
            new RouteVoyage
                { Id = 12,Order = 5, Duration = 65, ArrivalPlaceId = places[15].Id, DeparturePlaceId = places[16].Id, RouteId = routes[0].Id },
            new RouteVoyage
                { Id = 13,Order = 6, Duration = 30, ArrivalPlaceId = places[2].Id, DeparturePlaceId = places[15].Id, RouteId = routes[0].Id },

        };
        
        modelBuilder.Entity<RouteVoyage>().HasData(routeVoyages);

    }
}