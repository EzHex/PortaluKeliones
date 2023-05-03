using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class Trip : IEntityTypeConfiguration<Trip>
{
    public int Id { get; set; }
    [DisplayName("Išvykimo laikas")]
    public DateTime DepartureTime { get; set; }
    [DisplayName("Atvykimo laikas")]
    public DateTime ArrivalTime { get; set; }
    [DisplayName("Trukmė")]
    public TimeSpan Duration => ArrivalTime - DepartureTime;
    
    public Bus Bus { get; set; }
    public List<Route> Routes { get; set; }
    
    public List<Ticket> Tickets { get; set; }

    public Trip(DateTime departureTime, DateTime arrivalTime)
    {
        DepartureTime = departureTime;
        ArrivalTime = arrivalTime;
    }

    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.HasMany(t => t.Routes)
            .WithOne(t => t.Trip)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Tickets)
            .WithOne(t => t.Trip)
            .OnDelete(DeleteBehavior.Cascade);
    }
}