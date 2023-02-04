using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class PortalsDbContext : DbContext
{
    public PortalsDbContext(DbContextOptions<PortalsDbContext> options) : base(options) { }
    
    public PortalsDbContext() : base () { }

    
}
