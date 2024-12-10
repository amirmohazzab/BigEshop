using BigEshop.Application.Extensions;
using BigEshop.Data.Context;
using BigEshop.Domain.Models.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class MegaMenuViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int userId = HttpContext.User.GetUserId();

            var order = context.Orders.FirstOrDefault(o => o.UserId == userId && !o.IsFinally);

            List<OrderDetail> list = new List<OrderDetail>();

            if (order != null)
            {
                list.AddRange(context.OrderDetails.Where(o => o.OrderId == order.Id && !o.IsDelete)
                    .Include(p => p.Product).ThenInclude(p => p.ProductReactions));
            }

            ViewData["ProductReactions"] = await context
                .ProductReactions.Where(p => p.Reaction == true && p.UserId == userId).ToListAsync();

            ViewData["Categories"] = await context.ProductCategories.Where(c => !c.IsDelete).ToListAsync();
            var cat = ViewData["Categories"];

            return View("/Views/Shared/Components/MegaMenu.cshtml", list);
        }
    }
}
