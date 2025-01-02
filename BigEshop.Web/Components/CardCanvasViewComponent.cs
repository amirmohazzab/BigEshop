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

            var order = await context.Orders
                .Include(O => O.OrderDetails)
                .ThenInclude(O => O.Product)
                .Include(O => O.OrderDetails)
                .ThenInclude(O => O.ProductColor)
                .FirstOrDefaultAsync(o => o.UserId == userId && !o.IsFinally);
            
            return View("/Views/Shared/Components/CardCanvas.cshtml", order);
        }
    }
}
