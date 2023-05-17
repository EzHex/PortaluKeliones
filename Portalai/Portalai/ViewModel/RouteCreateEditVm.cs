using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Serialization;
using Portalai.Models;
using Route = Portalai.Models.Route;

namespace Portalai.ViewModel;

public class RouteCreateEditVm
{
    public class RouteVoyageM
    {
        public RouteVoyageM(int order, int placeId, int duration)
        {
            Order = order;
            PlaceId = placeId;
            Duration = duration;
        }

        public RouteVoyageM()
        {
        }

        public int Order { get; set; }
        
        [Required(ErrorMessage = "Privalomas laukas")]
        public int PlaceId { get; set; }
        
        [Range(1, 300, ErrorMessage = "Trukmė turi būti tarp 1 ir 300")]
        public int Duration { get; set; }
    }
    public IList<RouteVoyageM> RouteVoyageMs { get; set; }
    public IList<SelectListItem> PlaceSelectList { get; set; }
    public Route Route { get; set; }

    public RouteCreateEditVm()
    {
        // Initialize RouteVoyages, PlaceSelectList, and Route properties
        RouteVoyageMs = new List<RouteVoyageM>();
        PlaceSelectList = new List<SelectListItem>();
        Route = new Route();
    }

    public RouteCreateEditVm(List<RouteVoyageM> routeVoyages, IList<SelectListItem> placeSelectList, Route route)
    {
        RouteVoyageMs = routeVoyages;
        PlaceSelectList = placeSelectList;
        Route = route;
    }
}