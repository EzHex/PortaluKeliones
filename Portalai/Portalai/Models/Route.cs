using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portalai.Models;

public class Route : IEntityTypeConfiguration<Route>
{
    public int Id { get; set; }
    
    [DisplayName("Pavadinimas")]
    [Required(ErrorMessage = "Privalomas laukas")]
    public string Title { get; set; }

    //Mapping
    public virtual List<Trip>? Trips { get; set; }
    public virtual List<RouteVoyage> RouteVoyages { get; set; } = new List<RouteVoyage>();
    
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        // Route 1 : 0...N Trips
        builder.HasMany(m => m.Trips)
            .WithOne(m => m.Route)
            .IsRequired(false);
        
        // Route 1 : 1...N RouteVoyage
        builder.HasMany(m => m.RouteVoyages)
            .WithOne(m => m.Route);
    }
    
    [NotMapped]
    public List<Place> Places { get; set; } = new List<Place>();

    [NotMapped]
    public IList<SelectListItem>? AvailablePlaces { get; set; }

    public Route(string title)
    {
        Title = title;
    }

    public Route(int id, string title)
    {
        Id = id;
        Title = title;
    }

    public Route() { }

    public async Task LoadAvailableDropdowns(PortalsDbContext context)
    {
        var categories = await context.Places.ToListAsync();

        AvailablePlaces = categories.Select(x =>
        {
            return new SelectListItem()
            {
                Value = Convert.ToString(x.Id),
                Text = x.Name,
            };
        }).ToList();
    }
}