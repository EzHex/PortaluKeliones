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
    
    public RouteVoyage RouteVoyage { get; set; }

    public Voyage(DateTime departureTime, DateTime arrivalTime, double price)
    {
        DepartureTime = departureTime;
        ArrivalTime = arrivalTime;
        Price = price;
    }

    public void Configure(EntityTypeBuilder<Voyage> builder)
    {
        
    }
}