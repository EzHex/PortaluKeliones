using Microsoft.AspNetCore.Mvc;
using Portalai.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    
    public async Task<ActionResult> ShowOneComplaint(int id) 
    {
        var complaint = await context.Complaints
            .Include(m => m.Portal)
            .Include(m => m.User)
            .SingleAsync(x => x.Id == id);
        
        return View("ComplaintView", complaint);
    }

    public async Task<ActionResult> ShowDeleteConfirmForm(int id)
    {
        var complaint = await context.Complaints.SingleAsync(x => x.Id == id);
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
        catch (Exception)
        {
            ViewData["deletionNotPermitted"] = true;

            var compl = await context.Complaints.SingleAsync(x => x.Id == id);

            return View("ComplaintDelete", compl);
        }
    }
    
    public async Task<ActionResult> ShowEditStateForm(int id)
    {
        var complaint = await context.Complaints
            .Include(m => m.Portal)
            .Include(m => m.User)
            .SingleAsync(x => x.Id == id);
        return View("ComplaintEditState", complaint);
    }

    [HttpPost]
    public async Task<ActionResult> PostEditState(Complaint newElement)
    {
        ModelState["ComplaintHistories"].ValidationState = ModelValidationState.Valid;
        ModelState["ComplaintHistories"].Errors.Clear();
        ModelState["User"].ValidationState = ModelValidationState.Valid;
        ModelState["User"].Errors.Clear();
        ModelState["Portal"].ValidationState = ModelValidationState.Valid;
        ModelState["Portal"].Errors.Clear();

        if (!ModelState.IsValid)
            return View("ComplaintEditState", newElement);
        
        context.Complaints.Update(newElement);
        await context.SaveChangesAsync();
        
        var complaintHistory = new ComplaintHistory(DateTime.Now, newElement.Status, newElement.Comment, newElement);
        await context.ComplaintHistories.AddAsync(complaintHistory);
        await context.SaveChangesAsync();
        
        TempData["status"] = "Skundo būsena pakeista";
        return RedirectToAction("ShowComplaints");
    }
}