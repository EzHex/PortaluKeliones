using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class Place : IEntityTypeConfiguration<Place>
{
    public int Id { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public string Name { get; set; }
    
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        throw new NotImplementedException();
    }
}