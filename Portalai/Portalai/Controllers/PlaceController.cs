using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portalai.Models;

namespace Portalai.Controllers;

public class PlaceController : Controller
{
    private readonly PortalsDbContext context;

    public PlaceController(PortalsDbContext context)
    {
        this.context = context;
    }

    public async Task<ActionResult> PlacesList()
    {
        var places = await context.Places.ToListAsync();

        if (TempData["status"] != null)
        {
            ViewBag.Status = TempData["status"];
            TempData.Remove("status");
        }

        return View(places);
    }

    public async Task<ActionResult> PlaceCreate()
    {
        var place = new Place();

        return View(place);
    }

    [HttpPost]
    public async Task<ActionResult> PlaceCreate(Place place)
    {
        if (ModelState.IsValid)
        {
            await context.Places.AddAsync(place);
            await context.SaveChangesAsync();

            TempData["status"] = "Įrašas sėkmingai sukurtas";
            return RedirectToAction("PlacesList");
        }

        return View(place);
    }

    public async Task<ActionResult> PlaceEdit(int id)
    {
        var place = await context.Places.SingleAsync(x => x.Id == id);

        return View(place);
    }

    [HttpPost]
    public async Task<ActionResult> PlaceEdit(Place newPlace)
    {
        if (ModelState.IsValid)
        {
            var place = await context.Places.SingleAsync(x => x.Id == newPlace.Id);

            place.Longitude = newPlace.Longitude;
            place.Latitude = newPlace.Latitude;
            place.Name = newPlace.Name;

            await context.SaveChangesAsync();

            TempData["status"] = "Įrašas sėkmingai redaguotas";
            return RedirectToAction("PlacesList");
        }

        return View(newPlace);
    }

    public async Task<ActionResult> PlaceDelete(Place place)
    {
        return View(place);
    }

    [HttpPost]
    public async Task<ActionResult> PlaceDelete(int id)
    {
        try
        {
            var place = await context.Places.SingleAsync(x => x.Id == id);

            context.Remove(place);
            await context.SaveChangesAsync();

            TempData["status"] = "Įrašas sėkmingai pašalintas";
            return RedirectToAction("PlacesList");
        }
        catch (Exception e)
        {
            ViewData["deletionNotPermitted"] = true;

            var place = await context.Places.SingleAsync(x => x.Id == id);

            return View(place);
        }
    }

    public async Task<ActionResult> PlaceInfo(Place place)
    {
        return View(place);
    }
}