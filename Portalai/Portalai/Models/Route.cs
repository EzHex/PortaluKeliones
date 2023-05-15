using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    [NotMapped]
    public IList<SelectListItem> AvailablePlaces { get; set; }

    public Route(string title)
    {
        Title = title;
    }

    public Route()
    {

    }

    public void Configure(EntityTypeBuilder<Route> builder)
    {
        
    }

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