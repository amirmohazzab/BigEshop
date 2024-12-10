using BigEshop.Application.Extensions;
using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.UserPanel.Controllers
{
    public class OrderController (BigEshopContext context) : UserPanelBaseController
    {
        public async Task<IActionResult> Index()
        {
            int userId = User.GetUserId();

            var order = await context.Orders
                .Include(O => O.OrderDetails.Where(od => !od.IsDelete))
                .ThenInclude(O => O.Product)
                .Include(O => O.OrderDetails.Where(od => !od.IsDelete))
                .ThenInclude(O => O.ProductColor)
                .FirstOrDefaultAsync(o => o.UserId == userId && !o.IsFinally);

            return View(order);
        }
    }
}
