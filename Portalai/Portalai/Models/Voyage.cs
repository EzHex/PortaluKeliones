using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class Voyage : IEntityTypeConfiguration<Voyage>
{
    public int Id { get; set; }
    [DisplayName("Išvykimo laikas")]
    public DateTime DepartureTime { get; set; }
    [DisplayName("Atvykimo laikas")]
    public DateTime ArrivalTime { get; set; }
    [DisplayName("Kaina")]
    public double Price { get; set; }
    
    //Mapping

    public virtual RouteVoyage RouteVoyage { get; set; } = new RouteVoyage();
    public virtual Trip Trip { get; set; } = new Trip();

    public void Configure(EntityTypeBuilder<Voyage> builder)
    {
        // Voyage 0...N : 1 RouteVoyage   
        builder.HasOne(m => m.RouteVoyage)
            .WithMany(m => m.Voyage)
            .OnDelete(DeleteBehavior.NoAction);
        
        //Voyage 1...N : 1 Trip
        builder.HasOne(m => m.Trip)
            .WithMany(m => m.Voyages)
            .OnDelete(DeleteBehavior.Cascade);
    }
}