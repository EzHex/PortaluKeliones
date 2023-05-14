using Microsoft.AspNetCore.Mvc;

namespace Portalai.Controllers;

public class PortalController : Controller
{
    private readonly PortalsDbContext context;

    public PortalController(PortalsDbContext context)
    {
        this.context = context;
    }
    
    //TODO: Add portal reservation for activities
    //when portals will be implemented
}