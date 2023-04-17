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

    public async Task<ActionResult> ShowPlaces()
    {
        var places = await context.Places.ToListAsync();

        if (TempData["status"] != null)
        {
            ViewBag.Status = TempData["status"];
            TempData.Remove("status");
        }

        return View("PlacesList", places);
    }

    public async Task<ActionResult> ShowCreateForm()
    {
        var place = new Place();

        return View("PlaceCreate",place);
    }

    [HttpPost]
    public async Task<ActionResult> PostCreate(Place place)
    {
        if (ModelState.IsValid)
        {
            await context.Places.AddAsync(place);
            await context.SaveChangesAsync();

            TempData["status"] = "Įrašas sėkmingai sukurtas";
            return RedirectToAction("ShowPlaces");
        }

        return View("PlaceCreate", place);
    }

    public async Task<ActionResult> ShowEditForm(int id)
    {
        var place = await context.Places.SingleAsync(x => x.Id == id);

        return View("PlaceEdit", place);
    }

    [HttpPost]
    public async Task<ActionResult> PostEdit(Place newPlace)
    {
        if (ModelState.IsValid)
        {
            var place = await context.Places.SingleAsync(x => x.Id == newPlace.Id);

            place.Longitude = newPlace.Longitude;
            place.Latitude = newPlace.Latitude;
            place.Name = newPlace.Name;

            await context.SaveChangesAsync();

            TempData["status"] = "Įrašas sėkmingai redaguotas";
            return RedirectToAction("ShowPlaces");
        }

        return View("PlaceEdit", newPlace);
    }

    public async Task<ActionResult> ShowDeleteConfirmForm(Place place)
    {
        return View("PlaceDelete", place);
    }

    [HttpPost]
    public async Task<ActionResult> DeletePlace(int id)
    {
        try
        {
            var place = await context.Places.SingleAsync(x => x.Id == id);

            context.Remove(place);
            await context.SaveChangesAsync();

            TempData["status"] = "Įrašas sėkmingai pašalintas";
            return RedirectToAction("ShowPlaces");
        }
        catch (Exception e)
        {
            ViewData["deletionNotPermitted"] = true;

            var place = await context.Places.SingleAsync(x => x.Id == id);

            return View("PlaceDelete", place);
        }
    }

    public async Task<ActionResult> ShowOnePlace(Place place) 
    {
        return View("PlaceInfo", place);
    }
}