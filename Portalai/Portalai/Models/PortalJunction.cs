using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class PortalJunction : IEntityTypeConfiguration<PortalJunction>
{
    public int Id { get; set; }
    
    public List<Portal> Portals { get; set; }
    
    public void Configure(EntityTypeBuilder<PortalJunction> builder)
    {
        builder.HasMany(p => p.Portals)
            .WithOne(p => p.PortalJunction)
            .OnDelete(DeleteBehavior.NoAction);
    }
}