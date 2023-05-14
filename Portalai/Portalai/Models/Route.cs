using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class Route : IEntityTypeConfiguration<Route>
{
    public int Id { get; set; }
    [DisplayName("Pavadinimas")]
    public string Title { get; set; }
    
    public Trip Trip { get; set; }
    
    public List<RouteVoyage> RouteVoyages { get; set; } = new List<RouteVoyage>();
    
    [NotMapped]
    public List<Place> Places { get; set; } = new List<Place>();

    public Route(string title)
    {
        Title = title;
    }

    public void Configure(EntityTypeBuilder<Route> builder)
    {
        
    }
}