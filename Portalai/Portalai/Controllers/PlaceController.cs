using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
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
    
    public async Task<ActionResult> Index()
    {
        var places = await context.Places.ToListAsync();

        return View(places);
    }

    public async Task<ActionResult> Create()
    {
        var place = new Place();
        
        return View(place);
    }
    
    [HttpPost]
    public async Task<ActionResult> Create(Place place)
    {
        if (ModelState.IsValid)
        {
            await context.Places.AddAsync(place);
            await context.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
        
        return View(place);
    }

    public async Task<ActionResult> Edit(int id)
    {
        var place = await context.Places.SingleAsync(x => x.Id == id);

        return View(place);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(Place newPlace)
    {
        if (ModelState.IsValid)
        {
            var place = await context.Places.SingleAsync(x => x.Id == newPlace.Id);

            place.Longitude = newPlace.Longitude;
            place.Latitude = newPlace.Latitude;
            place.Name = newPlace.Name;

            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        return View(newPlace);
    }

    public async Task<ActionResult> Delete(Place place)
    {
        return View(place);
    }
    
    [HttpPost]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var place = await context.Places.SingleAsync(x => x.Id == id);
            
            context.Remove(place);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            ViewData["deletionNotPermitted"] = true;

            var place = await context.Places.SingleAsync(x => x.Id == id);
            
            return View(place);
        }
    }
    
    public async Task<ActionResult> Read(Place place)
    {
        return View(place);
    }
}