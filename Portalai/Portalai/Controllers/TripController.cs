using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portalai.Models;
using Portalai.ViewModel;

namespace Portalai.Controllers;

public class TripController : Controller
{
    private readonly PortalsDbContext _context;

    public TripController(PortalsDbContext context)
    {
        this._context = context;
    }


    public async Task<IActionResult> ShowCreateForm()
    {
        var vm = new TripCreateEditVM();

        vm.BusSelectList = new List<SelectListItem>((await _context.Buses.ToListAsync())
            .Select(x => new SelectListItem(x.Model + " " + x.Brand +
                                            " " + x.LicensePlate, x.Id.ToString())).ToList());

        vm.RouteSelectList = new List<SelectListItem>((await _context.Routes.ToListAsync())
            .Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList());

        vm.TripModel.DepartureTime = DateTime.Now;

        return View("TripCreate", vm);
    }

    public async Task<IActionResult> ShowOneTrip(int id)
    {
        Trip trip = await _context.Trips
            .Include(t => t.Voyages)
            .ThenInclude(v => v.RouteVoyage)
            .ThenInclude(rv => rv.Arrival)
            .Include(t => t.Voyages)
            .ThenInclude(v => v.RouteVoyage)
            .ThenInclude(rv => rv.Departure)
            .Include(t => t.Route)
            .FirstOrDefaultAsync(t => t.Id == id) ?? throw new InvalidOperationException();

        return View("TripInfo", trip);
    }

    public IActionResult ShowEditForm(int id)
    {
        Trip trip = _context.Trips
            .Include(t=>t.Voyages)
            .FirstOrDefault(t => t.Id == id) ?? throw new InvalidOperationException();
        return View("TripEdit", trip);
    }

    //Show delete confirm form
    public IActionResult ShowDeleteConfirmForm(int id)
    {
        var trip = _context.Trips
            .Include(t => t.Route) //SELECT ROUTE ---> ROUTE
            .FirstOrDefault(t => t.Id == id) ?? throw new InvalidOperationException(); //SELECT TRIP ---> Trip
        
        //OPEN DeleteConfirmForm()
        return View("TripDelete", trip);
    }

    public async Task<IActionResult> ShowTrips()
    {
        var trips = await _context.Trips
            .Include(t => t.Route)
            .Include(t => t.Bus)
            .ToListAsync();
        
        if (TempData["status"] != null)
        {
            ViewBag.Status = TempData["status"];
            TempData.Remove("status");
        }

        return View("TripList", trips);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TripCreateEditVM vm)
    {
        //chech if date is after today
        if (vm.TripModel.DepartureTime < DateTime.Now.AddHours(1))
        {
            ModelState.AddModelError("TripModel.DepartureTime",
                "Data negali būti praeityje ir valanda turi būti didesnė nei 1 valanda nuo dabar");
        }

        if (!ModelState.IsValid)
        {
            vm.BusSelectList = new List<SelectListItem>((await _context.Buses.ToListAsync())
                .Select(x => new SelectListItem(x.Model + " " + x.Brand +
                                                " " + x.LicensePlate, x.Id.ToString())).ToList());

            vm.RouteSelectList = new List<SelectListItem>((await _context.Routes.ToListAsync())
                .Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList());
            return View("TripCreate", vm);
        }

        var bus = await _context.Buses.FindAsync(vm.TripModel.BusId);
        var route = await _context.Routes.FindAsync(vm.TripModel.RouteId);
        //create trip

        if (bus != null && route != null)
        {
            var trip = new Trip()
            {
                Bus = bus,
                Route = route,
                DepartureTime = vm.TripModel.DepartureTime
            };

            //get route voyages
            var routeVoyages = await _context.RouteVoyages
                .Where(x => x.RouteId == route.Id)
                .ToListAsync();

            var departure = vm.TripModel.DepartureTime;

            //create trip voyages
            var tripVoyages = new List<Voyage>();
            foreach (var routeVoyage in routeVoyages)
            {
                var tripVoyage = new Voyage
                {
                    Trip = trip,
                    RouteVoyage = routeVoyage,
                    DepartureTime = departure,
                    ArrivalTime = departure.AddMinutes(routeVoyage.Duration),
                    Price = RandomNumberGenerator.GetInt32(5, 20)
                };
                departure = departure.AddMinutes(routeVoyage.Duration);
                tripVoyages.Add(tripVoyage);
            }

            //add trip voyages to trip
            trip.Voyages = tripVoyages;

            //update trip arrival
            trip.ArrivalTime = tripVoyages.Last().ArrivalTime;

            //add trip to db
            await _context.Trips.AddAsync(trip);
            await _context.SaveChangesAsync();
        }


        TempData["status"] = "Įrašas sėkmingai sukurtas";
        return RedirectToAction("ShowTrips");
    }

    //deleteTrip()
    public IActionResult DeleteTrip(Trip trip)
    {
        _context.Trips.Remove(trip);
        _context.SaveChanges();
        TempData["status"] = "Įrašas sėkmingai ištrintas";
        return RedirectToAction("ShowTrips");
    }

    [HttpPost]
    public IActionResult Edit(Trip trip)
    {
        //Fix voyage items - times
        var voyages = trip.Voyages;
        
        //get diff between old and new departure time
        var diff = trip.DepartureTime - trip.Voyages.First().DepartureTime;
        
        //update departure and arrival times
        foreach (var voyage in voyages)
        {
            voyage.DepartureTime = voyage.DepartureTime.Add(diff);
            voyage.ArrivalTime = voyage.ArrivalTime.Add(diff);
        }
        
        //update trip arrival time
        trip.ArrivalTime = trip.ArrivalTime.Add(diff);
        
        //update trip
        _context.Trips.Update(trip);
        _context.SaveChanges();
        TempData["status"] = "Įrašas sėkmingai atnaujintas";
        
        //redirect to trips list
        return RedirectToAction("ShowTrips");
    }
}