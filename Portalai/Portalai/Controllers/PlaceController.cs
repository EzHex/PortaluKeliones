using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
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

    public Task<ActionResult> ShowCreateForm()
    {
        var place = new Place();

        return Task.FromResult<ActionResult>(View("PlaceCreate",place));
    }

    [HttpPost]
    public async Task<ActionResult> PostCreate(Place place)
    {
        if (!ModelState.IsValid) 
            return View("PlaceCreate", place);
        
        await context.Places.AddAsync(place);
        await context.SaveChangesAsync();

        TempData["status"] = "Įrašas sėkmingai sukurtas";
        return RedirectToAction("ShowPlaces");
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

    public Task<ActionResult> ShowDeleteConfirmForm(Place place)
    {
        return Task.FromResult<ActionResult>(View("PlaceDelete", place));
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
        catch (DbUpdateException ex)
        {
            var sqlException = ex.GetBaseException() as SqlException;
            
            //Handle Database.Restrict message
            if (sqlException?.Number == 547)
            {
                //Set deletionNotPermitted to true
                ViewData["deletionNotPermitted"] = true;
                
                //Add error message to ModelState
                ModelState.AddModelError("", "Negalima ištrinti įrašo, nes jis yra susietas su kitais įrašais (maršrutais).");

            }

            var place = await context.Places.SingleAsync(x => x.Id == id);

            return View("PlaceDelete", place);
        }
    }

    public Task<ActionResult> ShowOnePlace(Place place) 
    {
        return Task.FromResult<ActionResult>(View("PlaceInfo", place));
    }
}