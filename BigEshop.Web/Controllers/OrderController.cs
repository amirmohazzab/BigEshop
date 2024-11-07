using BigEshop.Application.Extensions;
using BigEshop.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Controllers
{
    [Authorize]
    public class OrderController (BigEshopContext context) : Controller
    {
        [HttpGet("/Cart")]
        public async Task<IActionResult> Index()
        {
            int userId = User.GetUserId();

            var order = await context.Orders
                .Include(O => O.OrderDetails)
                .ThenInclude(O => O.Product)
                .Include(O => O.OrderDetails)
                .ThenInclude(O => O.ProductColor)
                .FirstOrDefaultAsync(o => o.UserId == userId &&  !o.IsFinally);

            return View(order);
        }
    }
}
