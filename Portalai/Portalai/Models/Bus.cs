using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class Bus : IEntityTypeConfiguration<Bus>
{
    public int Id { get; set; }
    [DisplayName("Valstybiniai numeriai")]
    public string LicensePlate { get; set; }
    [DisplayName("Markė")]
    public string Brand { get; set; }
    [DisplayName("Modelis")]
    public string Model { get; set; }
    [DisplayName("Pagaminimo data")]
    public DateTime ManufactureDate { get; set; }
    [DisplayName("Degalų tipas")]
    public FuelTypes Fuel { get; set; }
    [DisplayName("Sėdimų vietų skaičius")]
    [Range(1, 100)]
    public int Seats { get; set; }
    [DisplayName("Būsena")]
    public BusStatus Status { get; set; }
    
    [DisplayName("Būsena")]
    [NotMapped]
    public BusStatus NewStatus { get; set; }
    
    public List<Trip> Trips { get; set; }

    public Bus(string licensePlate, string brand, string model, DateTime manufactureDate, FuelTypes fuel, int seats, BusStatus status = BusStatus.Garage)
    {
        LicensePlate = licensePlate;
        Brand = brand;
        Model = model;
        ManufactureDate = manufactureDate;
        Fuel = fuel;
        Seats = seats;
        Status = status;
    }
    
    public Bus()
    {
        
    }

    public void Configure(EntityTypeBuilder<Bus> builder)
    {
        builder.HasMany(b => b.Trips)
            .WithOne(t => t.Bus)
            .OnDelete(DeleteBehavior.NoAction);
    }
}