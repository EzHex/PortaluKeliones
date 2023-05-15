using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Portalai.Models;

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

    public async Task<ActionResult> ShowOnePortal(int id)
    {
        var portal = await context.Portals
            .Include(m => m.PortalJunction)
            .SingleAsync(x => x.Id == id);

        if (portal.PortalJunction != null)
        {
            var secondPortal = await context.Portals.FirstOrDefaultAsync(o =>
                o.PortalJunction.Id == portal.PortalJunction.Id && o.Id != portal.Id);

            if (secondPortal != null)
            {
                portal.JunctionPortalId = secondPortal.Id;
            }
        }
        
        return View("PortalInfo", portal);
    }
     
    //TODO su klaustuku del listo
    public async Task<ActionResult> ShowEditForm(int id)
    {
        var portal = await context.Portals
            .Include(m => m.PortalJunction)
            .SingleAsync(x => x.Id == id);
        
        if (portal.PortalJunction != null)
        {
            var secondPortal = await context.Portals.FirstOrDefaultAsync(o =>
                o.PortalJunction.Id == portal.PortalJunction.Id && o.Id != portal.Id);

            if (secondPortal != null)
            {
                portal.JunctionPortalId = secondPortal.Id;
            }
        }
        
        var portalList = await context.Portals.ToListAsync();
        portal.PortalsList = portalList;
        
        return View("PortalEdit", portal);
    }

    [HttpPost]
    public async Task<ActionResult> PostEdit(Portal newElement)
    {
        ModelState["Complaints"].ValidationState = ModelValidationState.Valid;
        ModelState["Complaints"].Errors.Clear();

        if (!ModelState.IsValid)
            return View("PortalEdit", newElement);
        
        context.Portals.Update(newElement);
        await context.SaveChangesAsync();

        TempData["status"] = "Portalas sėkmingai atnaujintas";
        return RedirectToAction("ShowPortals");
    }
    
    public async Task<ActionResult> ShowCreateForm()
    {
        return RedirectToAction("ShowPortalReservation");
    }
    
    public async Task<ActionResult> ShowDeleteConfirmForm()
    {
        return RedirectToAction("ShowPortalReservation");
    }
    
    public async Task<ActionResult> ShowPortalReservation()
    {
        var portals = await context.Portals.ToListAsync();

        return View("PortalReserve", portals);
    }

    public async Task<ActionResult> PostReservation(Portal portal)
    {
        ModelState["Complaints"].ValidationState = ModelValidationState.Valid;
        ModelState["Complaints"].Errors.Clear();
        
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
}