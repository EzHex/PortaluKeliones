using Microsoft.EntityFrameworkCore;
using Portalai.Models;

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
    
}