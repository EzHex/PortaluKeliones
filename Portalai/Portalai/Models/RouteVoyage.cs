using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class RouteVoyage : IEntityTypeConfiguration<RouteVoyage>
{
    public int Id { get; set; }
    
    [DisplayName("Eilės numeris")]
    public int Order { get; set; }
    [DisplayName("Išvykimo laikas")]
    public DateTime DepartureTime { get; set; }
    [DisplayName("Atvykimo laikas")]
    public DateTime ArrivalTime { get; set; }
    [DisplayName("Trukmė")]
    public TimeSpan Duration => ArrivalTime - DepartureTime;
    public virtual Route Route { get; set; }
    
    public virtual List<Voyage> Voyage { get; set; }
    
    [ForeignKey("ArrivalPlaceId")]
    public virtual Place Arrival { get; set; }
    [ForeignKey("DeparturePlaceId")]
    public virtual Place Departure { get; set; }

    [NotMapped]
    public int ListId { get; set; }
    
    public RouteVoyage(int order, DateTime departureTime, DateTime arrivalTime)
    {
        Order = order;
        DepartureTime = departureTime;
        ArrivalTime = arrivalTime;
    }

    public RouteVoyage() { }

    public void Configure(EntityTypeBuilder<RouteVoyage> builder)
    {
        // RouteVoyage 1 : 0...N Voyage
        builder.HasMany(r => r.Voyage)
            .WithOne(r => r.RouteVoyage)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
        
        // RouteVoyage 1...N : 1 Route
        builder.HasOne(r => r.Route)
            .WithMany(r => r.RouteVoyages)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Arrival)
            .WithMany(m => m.ArrivalVoyages)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Departure)
            .WithMany(m => m.DepartureVoyages)
            .OnDelete(DeleteBehavior.Cascade);
    }
}