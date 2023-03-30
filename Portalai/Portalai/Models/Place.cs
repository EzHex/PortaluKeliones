using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class Place : IEntityTypeConfiguration<Place>
{
    public int Id { get; set; }

    [DisplayName("Ilguma")] public double Longitude { get; set; }

    [DisplayName("Platuma")] public double Latitude { get; set; }

    [DisplayName("Vietovės pavadinimas")] public string Name { get; set; }

    public void Configure(EntityTypeBuilder<Place> builder)
    {
        throw new NotImplementedException();
    }
}