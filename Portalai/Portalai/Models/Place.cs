using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class Place : IEntityTypeConfiguration<Place>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [DisplayName("Ilguma")] 
    [Range(-180,180)]
    public double Longitude { get; set; }

    [DisplayName("Platuma")] 
    [Range(-90,90)]
    public double Latitude { get; set; }

    [DisplayName("Vietovės pavadinimas")] 
    public string Name { get; set; }
    
    //Constructor

    public Place(int id, string name, double longitude, double latitude)
    {
        Id = id;
        Longitude = longitude;
        Latitude = latitude;
        Name = name;
    }

    public Place()
    {
    }

    //Mapping

    [InverseProperty("Arrival")]
    public virtual List<RouteVoyage>? ArrivalVoyages { get; set; }
    [InverseProperty("Departure")]
    public virtual List<RouteVoyage>? DepartureVoyages { get; set; }
    
    public virtual List<EducationalRoute>? EducationalRoutes { get; set; }

    //TODO iskelt configure paskui i atskira file nes specify twice nepadeda
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        // Place 1 : 0...N RouteVoyage (ARRIVAL)
        builder.HasMany(m => m.ArrivalVoyages)
            .WithOne(m => m.Arrival)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
        
        // Place 1 : 0...N RouteVoyage (DEPARTURE)
        builder.HasMany(m => m.DepartureVoyages)
            .WithOne(m => m.Departure)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}