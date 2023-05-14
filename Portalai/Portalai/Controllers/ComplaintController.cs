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

        return View("ComplaintList", complaints);
    }
    
    public async Task<ActionResult> ShowOneComplaint(Complaint complaint) 
    {
        return View("ComplaintView", complaint);
    }
}