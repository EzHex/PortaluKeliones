using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Portalai.Models;

namespace Portalai.Controllers;

public class BusController : Controller
{
    private readonly PortalsDbContext _context;

    public BusController(PortalsDbContext context)
    {
        this._context = context;
    }
    
    public async Task<ActionResult> ShowBusesList()
    {
        var buses = await _context.Buses.ToListAsync();

        if (TempData["status"] != null)
        {
            ViewBag.Status = TempData["status"]!;
            TempData.Remove("status");
        }

        return View("BusesList", buses);
    }

    public async Task<ActionResult> ShowStatusChangeForBus(int id)
    {
        var bus = await _context.Buses.SingleAsync(x => x.Id == id);
        bus.NewStatus = bus.Status;

        return View("BusStatus", bus);
    }

    [HttpPost]
    public async Task<ActionResult> CheckIfStatusAvailable(int id, BusStatus newStatus)
    {
        var bus = await _context.Buses.SingleAsync(x => x.Id == id);

        switch (bus.Status)
        {
            case BusStatus.Garage:
                if (newStatus is BusStatus.OnRoute or BusStatus.Broken)
                {
                    TempData["status"] = "Autobuso būsena sėkmingai pakeistas";
                    bus.Status = newStatus;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ShowBusesList");
                }
                ModelState.AddModelError("NewStatus", "Tokia būsena negalima");
                return View("BusStatus", bus);
            case BusStatus.OnRoute:
                if (newStatus is BusStatus.Garage or BusStatus.Broken)
                {
                    TempData["status"] = "Autobuso būsena sėkmingai pakeistas";
                    bus.Status = newStatus;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ShowBusesList");
                }
                ModelState.AddModelError("NewStatus", "Tokia būsena negalima");
                return View("BusStatus", bus);
            case BusStatus.Broken:
                if (newStatus is BusStatus.Repair)
                {
                    TempData["status"] = "Autobuso būsena sėkmingai pakeistas";
                    bus.Status = newStatus;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ShowBusesList");
                }
                ModelState.AddModelError("NewStatus", "Tokia būsena negalima");
                return View("BusStatus", bus);
            case BusStatus.Repair:
                if (newStatus is BusStatus.Garage)
                {
                    TempData["status"] = "Autobuso būsena sėkmingai pakeistas";
                    bus.Status = newStatus;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ShowBusesList");
                }
                ModelState.AddModelError("NewStatus", "Tokia būsena negalima");
                return View("BusStatus", bus);
            default:
                return View("BusStatus", bus);
        }
    }
    
    public Task<ActionResult> ShowCreateForm()
    {
        var bus = new Bus();

        return Task.FromResult<ActionResult>(View("BusCreate", bus));
    }
    
    [HttpPost]
    public async Task<ActionResult> PostBusCreate(Bus bus)
    {
        ModelState["Trips"].ValidationState = ModelValidationState.Valid;
        ModelState["Trips"].Errors.Clear();
        
        if (!ModelState.IsValid)
            return View("BusCreate", bus);
        
        await _context.Buses.AddAsync(bus);
        await _context.SaveChangesAsync();

        TempData["status"] = "Autobusas sėkmingai pridėtas";
        
        return RedirectToAction("ShowBusesList");
    }
    
    public async Task<ActionResult> ShowEditForm(int id)
    {
        var bus = await _context.Buses.SingleAsync(x => x.Id == id);

        return View("BusEdit", bus);
    }

    [HttpPost]
    public async Task<ActionResult> PostBusEdit(Bus bus)
    {
        ModelState["Trips"].ValidationState = ModelValidationState.Valid;
        ModelState["Trips"].Errors.Clear();
        
        if (!ModelState.IsValid)
            return View("BusEdit", bus);
        
        _context.Buses.Update(bus);
        await _context.SaveChangesAsync();
        
        TempData["status"] = "Autobusas sėkmingai atnaujintas";
        
        return RedirectToAction("ShowBusesList");
    }

    public Task<ActionResult> ShowBusDelete(Bus bus)
    {
        return Task.FromResult<ActionResult>(View("BusDelete", bus));
    }

    [HttpPost]
    public async Task<ActionResult> DeleteBus(int id)
    {
        try
        {
            var bus = await _context.Buses.SingleAsync(x => x.Id == id);

            _context.Buses.Remove(bus);
            await _context.SaveChangesAsync();

            TempData["status"] = "Autobusas sėkmingai pašalintas";

            return RedirectToAction("ShowBusesList");
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
                ModelState.AddModelError("",
                    "Negalima ištrinti įrašo, nes jis yra susietas su kitais įrašais (kelionemis).");

            }
            
            return View("BusDelete", await _context.Buses.SingleAsync(x => x.Id == id));
        }
    }
}