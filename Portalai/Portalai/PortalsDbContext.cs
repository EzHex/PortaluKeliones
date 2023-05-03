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
}