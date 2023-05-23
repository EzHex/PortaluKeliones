using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portalai.Models;

namespace Portalai.Controllers;

public class PortalController : Controller
{
    private readonly PortalsDbContext _context;

    public PortalController(PortalsDbContext context)
    {
        this._context = context;
    }

    public async Task<ActionResult> ShowPortals()
    {
        var portals = await _context.Portals.ToListAsync();

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
        var portal = _context.Portals
            .Include(m => m.PortalJunction)
            .ThenInclude(m => m.Portals)
            .Single(x => x.Id == id);

        return View("PortalInfo", portal);
    }

    //TODO su klaustuku del listo
    public async Task<ActionResult> ShowEditForm(int id)
    {
        //Get portal and junction with both portals
        var portal = await _context.Portals
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
                //set junction to null to safe update
                portal.PortalJunction = null;
                
                //Update the portal
                _context.Update(portal);
                //Save changes
                _context.SaveChanges();
            }
            else
            {
                //If it is connected to a different portal now
                //Remove it
                _context.Remove(currentJunction);
                //Save changes
                _context.SaveChanges();
                
                //Replace old portal with new one
                currentJunction.Portals.Remove(secondPortal);
                
                if (portal.JunctionPortalId != null)
                {
                    currentJunction.Portals.Add(_context.Portals.Single(x => x.Id == portal.JunctionPortalId));
                    //Remove junction id
                    currentJunction.Id = 0;
                    //Update the junction
                    _context.Add(currentJunction);
                }

                //Save changes
                _context.SaveChanges();
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
                newJunction.Portals.Add(_context.Portals.Single(x => x.Id == portal.JunctionPortalId));

                //Add the junction to the portal
                portal.PortalJunction = newJunction;
                
                //Detach mew junction
                _context.Entry(newJunction).State = EntityState.Detached;
                
                //Update the portal
                _context.Update(portal);
                
                //Save changes
                _context.SaveChanges();
            }
            else
            {
                //Update the portal
                _context.Update(portal);
                //Save changes
                _context.SaveChanges();
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
        var portal = _context.Portals
            .Include(m => m.PortalJunction)
            .ThenInclude(m => m.Portals)
            .Single(x => x.Id == id);
        
        return View("PortalDelete", portal);
    }

    public async Task<ActionResult> ShowPortalReservation()
    {
        var portals = await _context.Portals.ToListAsync();

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
            var portals = await _context.Portals.ToListAsync();
            return View("PortalReserve", portals);
        }

        var dbPortal = await _context.Portals.SingleAsync(x => x.Id == portal.Id);
        dbPortal.Status = PortalStatus.Reserved;
        await _context.SaveChangesAsync();

        return RedirectToAction("ShowPortalReservation");
    }

    public IActionResult PostCreate(Portal portal)
    {
        if (!ModelState.IsValid)
        {
            return View("PortalCreate", portal);
        }

        //create portal
        _context.Portals.Add(portal);
        _context.SaveChanges();
        //create junction if connected portal stated
        if (portal.JunctionPortalId != null)
        {
            // Add portal to junction
            var junction = new PortalJunction();
            junction.Portals.Add(portal);

            //get second portal and add it to junction
            var secondPortal = _context.Portals.Single(x => x.Id == portal.JunctionPortalId);
            junction.Portals.Add(secondPortal);

            _context.PortalJunctions.Add(junction);
        }

        _context.SaveChanges();

        TempData["status"] = "Portalas sėkmingai sukurtas";
        return RedirectToAction("ShowPortals");
    }

    public IActionResult DeletePortal(Portal portal)
    {
        //If it had a junction remove it
        if (portal.PortalJunction != null)
        {
            //Remove the junction
            _context.Remove(portal.PortalJunction);
            _context.SaveChanges();
            //Set the junction to null
            portal.PortalJunction = null;
        }
        
        _context.Remove(portal);
        _context.SaveChanges();
        
        TempData["status"] = "Portalas sėkmingai ištrintas";
        
        return RedirectToAction("ShowPortals");
    }
}