using BigEshop.Application.Extensions;
using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Components
{
    public class OrderViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int userId = HttpContext.User.GetUserId();

            var order = await context.Orders
                .Include(O => O.OrderDetails.Where(od => !od.IsDelete))
                .ThenInclude(O => O.Product)
                .Include(O => O.OrderDetails.Where(od => !od.IsDelete))
                .ThenInclude(O => O.ProductColor)
                .FirstOrDefaultAsync(o => o.UserId == userId && !o.IsFinally);

            return View("Order", order);
        }
    }
}
