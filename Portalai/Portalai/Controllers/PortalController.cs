using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Portalai.Models;
using Portalai.ViewModel;

namespace Portalai.Controllers;

public class PortalController : Controller
{
    private readonly PortalsDbContext context;

    public PortalController(PortalsDbContext context)
    {
        this.context = context;
    }

    public async Task<ActionResult> ShowPortals()
    {
        var portals = await context.Portals.ToListAsync();

        if (TempData["status"] != null)
        {
            ViewBag.Status = TempData["status"];
            TempData.Remove("status");
        }

        return View("PortalList", portals);
    }

    public ActionResult ShowOnePortal(int id)
    {
        //Get portal with junctions that has both portals
        var portal = context.Portals
            .Include(m => m.PortalJunction)
            .ThenInclude(m => m.Portals)
            .Single(x => x.Id == id);

        return View("PortalInfo", portal);
    }

    //TODO su klaustuku del listo
    public async Task<ActionResult> ShowEditForm(int id)
    {
        //Get portal and junction with both portals
        var portal = await context.Portals
            .Include(m => m.PortalJunction)
            .ThenInclude(m => m.Portals)
            .SingleAsync(x => x.Id == id);

        return View("PortalEdit", portal);
    }

    [HttpPost]
    public ActionResult PostEdit(Portal portal)
    {
        if (!ModelState.IsValid)
            return View("PortalEdit", portal);
        //Check if the portal WAS connected
        var currentJunction = portal.PortalJunction;

        //IF IT WAS CONNECTED
        if (currentJunction != null)
        {
            //Get the portal it was connected to FROM CURRENT JUNCTION
            var secondPortal = currentJunction.Portals.Single(x => x.Id != portal.Id);
            
            //If it is still connected and changed only the portal data
            if (secondPortal.Id == portal.JunctionPortalId)
            {
                //set currentJunction portals to null
                currentJunction.Portals = null;
                //Update the portal
                context.Update(portal);
                //Save changes
                context.SaveChanges();
            }
            else
            {
                //If it is connected to a different portal now
                
                //Remove old junction
                context.Remove(currentJunction);
                
                //Update the portal
                context.Update(portal);
                //Save changes
                context.SaveChanges();
            }
        }
        else
        {
            //IF IT WAS NOT CONNECTED
            //Check if we are connecting it to another portal
            if (portal.JunctionPortalId != null)
            {
                //Create a new junction
                var newJunction = new PortalJunction();
                //Add both portals to the junction
                newJunction.Portals.Add(portal);
                newJunction.Portals.Add(context.Portals.Single(x => x.Id == portal.JunctionPortalId));
                //Add the junction to the portal
                portal.PortalJunction = newJunction;
                
                //Add the junction to the database
                context.PortalJunctions.Add(newJunction);
                
                //Update the portal
                context.Update(portal);
                
                //Save changes
                context.SaveChanges();
            }
        }

        TempData["status"] = "Portalas sėkmingai atnaujintas";
        return RedirectToAction("ShowPortals");
    }

    public ViewResult ShowCreateForm()
    {
        //Create empty portal
        var portal = new Portal();

        return View("PortalCreate", portal);
    }

    public ActionResult ShowDeleteConfirmForm(int id)
    {
        //Load portal and its junction if it has one
        var portal = context.Portals
            .Include(m => m.PortalJunction)
            .ThenInclude(m => m.Portals)
            .Single(x => x.Id == id);
        
        return View("PortalDelete", portal);
    }

    public async Task<ActionResult> ShowPortalReservation()
    {
        var portals = await context.Portals.ToListAsync();

        return View("PortalReserve", portals);
    }

    public async Task<ActionResult> PostReservation(Portal portal)
    {
        switch (portal.Status)
        {
            case PortalStatus.Reserved:
                ModelState.AddModelError("", "Portalas jau rezervuotas");
                break;
            case PortalStatus.InMaintenance:
                ModelState.AddModelError("", "Portalas yra remontuojamas");
                break;
            case PortalStatus.NotWorking:
                ModelState.AddModelError("", "Portalas neveikia");
                break;
        }

        if (!ModelState.IsValid)
        {
            var portals = await context.Portals.ToListAsync();
            return View("PortalReserve", portals);
        }

        var dbPortal = await context.Portals.SingleAsync(x => x.Id == portal.Id);
        dbPortal.Status = PortalStatus.Reserved;
        await context.SaveChangesAsync();

        return RedirectToAction("ShowPortalReservation");
    }

    public IActionResult PostCreate(Portal portal)
    {
        if (!ModelState.IsValid)
        {
            return View("PortalCreate", portal);
        }

        //create portal
        context.Portals.Add(portal);
        context.SaveChanges();
        //create junction if connected portal stated
        if (portal.JunctionPortalId != null)
        {
            // Add portal to junction
            var junction = new PortalJunction();
            junction.Portals.Add(portal);

            //get second portal and add it to junction
            var secondPortal = context.Portals.Single(x => x.Id == portal.JunctionPortalId);
            junction.Portals.Add(secondPortal);

            context.PortalJunctions.Add(junction);
        }

        context.SaveChanges();

        TempData["status"] = "Portalas sėkmingai sukurtas";
        return RedirectToAction("ShowPortals");
    }

    public IActionResult DeletePortal(Portal portal)
    {
        //If it had a junction remove it
        if (portal.PortalJunction != null)
        {
            portal.PortalJunction.Portals = null;
        }

        //Remove portal and its junctipn if it has one (CASCADE)
        context.Remove(portal);
        context.SaveChanges();
        
        TempData["status"] = "Portalas sėkmingai ištrintas";
        
        return RedirectToAction("ShowPortals");
    }
}