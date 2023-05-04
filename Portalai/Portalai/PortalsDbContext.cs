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
    
}