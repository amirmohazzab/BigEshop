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
                list.AddRange(context.OrderDetails.Where(o => o.OrderId == order.Id)
                    .Include(p => p.Product));
            }

            return View("/Views/Shared/Components/MegaMenu.cshtml", list);
        }
    }
}
