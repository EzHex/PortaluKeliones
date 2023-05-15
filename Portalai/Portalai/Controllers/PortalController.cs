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