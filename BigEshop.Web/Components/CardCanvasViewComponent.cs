using BigEshop.Data.Context;
using BigEshop.Application.Extensions;
using BigEshop.Domain.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BigEshop.Domain.Models.Order;
using System.Security.Claims;

namespace BigEshop.Web.Components
{
    
    public class CardCanvasViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int userId = HttpContext.User.GetUserId();

            var order = context.Orders.FirstOrDefault(o => o.UserId == userId && !o.IsFinally);

            List<OrderDetail> list = new List<OrderDetail>();

            if (order != null)
            {
                list.AddRange(context
                    .OrderDetails.Where(o => o.OrderId == order.Id && !o.IsDelete)
                    .Include(p => p.Product).ThenInclude(p => p.ProductColors));
            }
            ViewBag.Count = list.Count;
            //ViewBag.ISFINALLY = order.IsFinally;
            // ViewBag.Price = _context.Products.FirstOrDefault(p => p.ProductId == )

            return View("/Views/Shared/Components/CardCanvas.cshtml", list);
        }
    }
}
