using Microsoft.AspNetCore.Mvc;
using Portalai.Models;
using Microsoft.EntityFrameworkCore;

namespace Portalai.Controllers;

public class ComplaintController : Controller
{
    private readonly PortalsDbContext context;

    public ComplaintController(PortalsDbContext context)
    {
        this.context = context;
    }

    public async Task<ActionResult> ShowComplaints()
    {
        var complaints = await context.Complaints.ToListAsync();
        
        if (TempData["status"] != null)
        {
            ViewBag.Status = TempData["status"];
            TempData.Remove("status");
        }
  
        return View("ComplaintList", complaints);
    }
    
    //TODO: Pataisyti, nes portalas ir user null
    public async Task<ActionResult> ShowOneComplaint(int id) 
    {
        var complaint = await context.Complaints.SingleAsync(x => x.Id == id);

        
        return View("ComplaintView", complaint);
    }

    public async Task<ActionResult> ShowDeleteConfirmForm(Complaint complaint)
    {
        return View("ComplaintDelete", complaint);
    }
    
    [HttpPost]
    public async Task<ActionResult> DeleteComplaint(int id)
    {
        try
        {
            var complaint = await context.Complaints.SingleAsync(x => x.Id == id);

            context.Remove(complaint);
            await context.SaveChangesAsync();

            TempData["status"] = "Įrašas sėkmingai pašalintas";
            return RedirectToAction("ShowComplaints");
        }
        catch (Exception e)
        {
            ViewData["deletionNotPermitted"] = true;

            var compl = await context.Complaints.SingleAsync(x => x.Id == id);

            return View("ComplaintDelete", compl);
        }
    }
}