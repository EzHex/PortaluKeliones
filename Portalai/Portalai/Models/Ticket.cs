using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class Ticket : IEntityTypeConfiguration<Ticket>
{
    public int Id { get; set; }
    [DisplayName("Sėdėjimo vieta")]
    public int Seat { get; set; }
    [DisplayName("Kaina")]
    public double Price { get; set; }
    [DisplayName("Pirkimo data")]
    public DateTime PurchaseDate { get; set; }
    [DisplayName("Išvykimo data")]
    public DateTime DepartureTime { get; set; }
    [DisplayName("Atvykimo data")]
    public DateTime ArrivalTime { get; set; }
    
    public Trip Trip { get; set; }
    public User User { get; set; }

    public Ticket()
    {
        
    }

    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasOne(u => u.User)
            .WithMany(t => t.Tickets)
            .OnDelete(DeleteBehavior.Cascade);
    }
}