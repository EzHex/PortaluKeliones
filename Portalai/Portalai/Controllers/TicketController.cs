using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Portalai.Controllers
{
    public class TicketController : Controller
    {
        private readonly PortalsDbContext context;

        public TicketController(PortalsDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
