using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class PortalJunction : IEntityTypeConfiguration<PortalJunction>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
    
    public List<Portal> Portals { get; set; } = null!;

    public void Configure(EntityTypeBuilder<PortalJunction> builder)
    {
        builder.HasMany(p => p.Portals)
            .WithOne(p => p.PortalJunction)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasCheckConstraint("CK_PortalJunction_PortalsCount", "COUNT(Portals) = 2");
    }
}