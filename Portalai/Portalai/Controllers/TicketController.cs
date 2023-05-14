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

        public async Task<ActionResult> ShowPurchasedTicketsList()
        {
            var tickets = await context.Tickets.Where(t => t.User.Id == 1).ToListAsync();

            return View("TicketsList", tickets);
        }
        
        //TODO: Buy tickets for routes/trips
    }
}
