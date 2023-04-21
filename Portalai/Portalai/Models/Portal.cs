using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class Portal : IEntityTypeConfiguration<Portal>
{

    public int Id { get; set; }

    [DisplayName("Ilguma")] 
    [Range(-180,180)]
    public double Longitude { get; set; }

    [DisplayName("Platuma")] 
    [Range(-90,90)]
    public double Latitude { get; set; }
    
    [DisplayName("Skysčio talpa")]
    public double LiquidCapacity { get; set; }
    
    [DisplayName("Esamas skysčio kiekis")]
    public double CurrentLiquidLevel { get; set; }
    
    [DisplayName("Teleportacijos kaina")]
    public double TeleportPrice { get; set; }
    
    [DisplayName("Teleportacijų skaičius")]
    public double TeleportCount { get; set; }
    
    [DisplayName("Būsena")]
    public PortalStatus Status { get; set; }
    
    public PortalJunction PortalJunction { get; set; }
    
    public void Configure(EntityTypeBuilder<Portal> builder)
    {
        builder.HasOne(p => p.PortalJunction)
            .WithMany(p => p.Portals)
            .OnDelete(DeleteBehavior.Cascade);
    }
}