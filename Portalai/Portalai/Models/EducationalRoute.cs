using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class EducationalRoute : IEntityTypeConfiguration<EducationalRoute>
{
    public int Id { get; set; }
    [DisplayName("Pavadinimas")]
    public string Title { get; set; }
    [DisplayName("Kaina")]
    public decimal Price { get; set; }
    [DisplayName("Išvykimo data")]
    public DateTime DepartureDate { get; set; }
    [DisplayName("Atvykimo data")]
    public DateTime ArrivalDate { get; set; }
    [DisplayName("Reitingas")]
    public int Rating { get; set; }
    [DisplayName("Reitingų skaičius")]
    public int RatingCount { get; set; }
    
    public List<Place> Places { get; set; }
    
    public void Configure(EntityTypeBuilder<EducationalRoute> builder)
    {
        // builder.HasMany(e => e.Places)
        //     .WithMany(e => e.EducationalRoutes);
    }
}