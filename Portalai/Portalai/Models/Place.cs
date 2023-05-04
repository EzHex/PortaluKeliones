using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class Place : IEntityTypeConfiguration<Place>
{
    public int Id { get; set; }

    [DisplayName("Ilguma")] 
    [Range(-180,180)]
    public double Longitude { get; set; }

    [DisplayName("Platuma")] 
    [Range(-90,90)]
    public double Latitude { get; set; }

    [DisplayName("Vietovės pavadinimas")] 
    public string Name { get; set; }

    public List<RouteVoyage> RouteVoyages { get; set; }
    
    public List<EducationalRoute> EducationalRoutes { get; set; }
    
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        throw new NotImplementedException();
    }
}