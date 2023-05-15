using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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

    public Route Routes { get; set; }
    
    public List<Voyage> Voyage { get; set; }
    
    public List<Place> Places { get; set; }

    [NotMapped]
    public int ListId { get; set; }
    
    public RouteVoyage(int order, DateTime departureTime, DateTime arrivalTime)
    {
        Order = order;
        DepartureTime = departureTime;
        ArrivalTime = arrivalTime;
    }
    public RouteVoyage()
    {
    }

    public void Configure(EntityTypeBuilder<RouteVoyage> builder)
    {
        builder.HasMany(r => r.Voyage)
            .WithOne(r => r.RouteVoyage)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(r => r.Routes)
            .WithMany(r => r.RouteVoyages)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.Places)
            .WithMany(r => r.RouteVoyages);
    }
}