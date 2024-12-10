using BigEshop.Application.Extensions;
using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Components
{
    public class TicketViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var tickets = await context.Tickets.Include(t => t.User).ToListAsync();

            return View("Ticket", tickets);
        }
    }
}
