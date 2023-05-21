using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class RouteVoyage : IEntityTypeConfiguration<RouteVoyage>
{
    public RouteVoyage(int order, int duration, Route route)
    {
        Order = order;
        Duration = duration;
        Route = route;
    }

    public RouteVoyage()
    {
    }

    public int Id { get; set; }

    [DisplayName("Eilės numeris")] public int Order { get; set; }

    [DisplayName("Trukmė (min)")]
    [Range(0, 300)]
    public int Duration { get; set; }

    public int RouteId { get; set; }

    [ForeignKey("RouteId")] public virtual Route Route { get; set; }

    public virtual List<Voyage>? Voyage { get; set; }

    public int ArrivalPlaceId { get; set; }

    [ForeignKey("ArrivalPlaceId")] public virtual Place Arrival { get; set; }

    public int DeparturePlaceId { get; set; }

    [ForeignKey("DeparturePlaceId")] public virtual Place Departure { get; set; }

    public void Configure(EntityTypeBuilder<RouteVoyage> builder)
    {
        // RouteVoyage 1 : 0...N Voyage
        builder.HasMany(r => r.Voyage)
            .WithOne(r => r.RouteVoyage)
            .IsRequired(false);

        // RouteVoyage 1...N : 1 Route
        builder.HasOne(r => r.Route)
            .WithMany(r => r.RouteVoyages)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Arrival)
            .WithMany(m => m.ArrivalVoyages)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Departure)
            .WithMany(m => m.DepartureVoyages)
            .OnDelete(DeleteBehavior.NoAction);
    }
}