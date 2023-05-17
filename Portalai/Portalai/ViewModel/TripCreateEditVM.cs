using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Portalai.Models;

namespace Portalai.ViewModel;

public class TripCreateEditVM
{
    public class TripM
    {
        [Required] public DateTime DepartureTime { get; set; }
        [Required] public int BusId { get; set; }
        [Required] public int RouteId { get; set; }
    }
    public TripM TripModel { get; set; }
    public IList<SelectListItem> BusSelectList { get; set; }
    public IList<SelectListItem> RouteSelectList { get; set; }
    
    public Trip Trip;

    public TripCreateEditVM()
    {
        Trip = new Trip();
        BusSelectList = new List<SelectListItem>();
        RouteSelectList = new List<SelectListItem>();
        TripModel = new TripM();
    }
}