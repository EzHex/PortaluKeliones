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
    
    //Mapping
    
    public virtual Bus Bus { get; set; }
    public virtual Route Route { get; set; }
    public virtual List<Voyage> Voyages { get; set; }
    
    public List<Ticket> Tickets { get; set; }

    public Trip(DateTime departureTime, DateTime arrivalTime)
    {
        DepartureTime = departureTime;
        ArrivalTime = arrivalTime;
    }

    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        // Trip 0...N : 1 Route
        builder.HasOne(m => m.Route)
            .WithMany(m => m.Trips);
        
        // Trip 1 : 1...N Voyage
        builder.HasMany(m => m.Voyages)
            .WithOne(m => m.Trip);
        
        // Trip 0...N : 1 Bus
        builder.HasOne(m => m.Bus)
            .WithMany(m => m.Trips);

        builder.HasMany(t => t.Tickets)
            .WithOne(t => t.Trip)
            .OnDelete(DeleteBehavior.Cascade);
    }
}