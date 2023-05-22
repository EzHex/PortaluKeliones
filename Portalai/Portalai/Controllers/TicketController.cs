using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayseraSim;
using Portalai.Models;
using Route = Portalai.Models.Route;

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
            var tickets = await context.Tickets
                .Include(t => t.Trip)
                    .ThenInclude(t => t.Bus)
                .Include(t => t.Trip.Route.RouteVoyages)
                    .ThenInclude(rv => rv.Arrival)
                .Include(t => t.Trip.Route.RouteVoyages)
                    .ThenInclude(rv => rv.Departure)
                .Where(t => t.User.Id == 1)
                .ToListAsync();

            return View("TicketsList", tickets);
        }
        
        public async Task<ActionResult> MakeTicketPurchase(Route route)
        {
            if (!PayseraSim.Paysera.getStatus())
            {
                TempData["status"] = "Mokėjimas nepavyko";
                return RedirectToAction("ShowRoutesSearch", "Route");
            }

            var user = await context.Users.SingleAsync(x => x.Id == 1);

            var tickets = await context.Tickets.Where(t => t.Trip.Route.Id == route.Id).ToListAsync();
            var availableSeat = 0;
            if (tickets.Count != 0)
                availableSeat = tickets.Select(t => t.Seat).Max() + 1;
            
            var ticket = new Ticket();
            ticket.Seat = availableSeat;
            ticket.User = user;
            ticket.Trip = await context.Trips.Where(t => t.Route.Id == route.Id).FirstAsync();
            // TODO [extra] calculate price
            ticket.Price = 5;
            ticket.DepartureTime = DateTime.Now;
            ticket.ArrivalTime = DateTime.Now.AddHours(1);
            
            context.Tickets.Add(ticket);
            await context.SaveChangesAsync();

            TempData["status"] = "Mokėjimas pavyko";
            return RedirectToAction("ShowRoutesSearch", "Route");
        }
    }
}
