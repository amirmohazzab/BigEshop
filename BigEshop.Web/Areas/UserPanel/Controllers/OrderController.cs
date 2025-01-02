using BigEshop.Application.Extensions;
using BigEshop.Data.Context;
using BigEshop.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.UserPanel.Controllers
{
    public class OrderController (BigEshopContext context,IOrderRepository orderRepository) : UserPanelBaseController
    {
        public async Task<IActionResult> Index()
        {
            int userId = User.GetUserId();

            var order = await context.Orders
                .Include(O => O.OrderDetails)
                .ThenInclude(O => O.Product)
                .Include(O => O.OrderDetails)
                .ThenInclude(O => O.ProductColor)
                .FirstOrDefaultAsync(o => o.UserId == userId && !o.IsFinally);

            //var order = await orderRepository.GetAllByUserIdAsync(userId);

            return View(order);
        }


    }
}
