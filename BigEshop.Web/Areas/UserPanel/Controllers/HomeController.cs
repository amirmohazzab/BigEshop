using BigEshop.Application.Extensions;
using BigEshop.Data.Context;
using BigEshop.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.UserPanel.Controllers
{
    public class HomeController (BigEshopContext context) : UserPanelBaseController
    {
        public async Task<IActionResult> Index()
        {
            var userId = User.GetUserId();

            ViewData["FavoriteProducts"] = await context.ProductReactions
                .Include(p => p.Product).Where(pr => pr.UserId == userId && pr.Reaction == true).ToListAsync();

            ViewData["VisitProducts"] = await context.ProductVisits
                .Include(p => p.Product).Where(pr => pr.UserId == userId && pr.Visit > 0).ToListAsync();

            var orders = await context.Orders
                .Include(u => u.User)
                .Include(p => p.OrderDetails.Where(o => o.IsDelete == false))
                .ThenInclude(p => p.Product)
                .Include(p => p.OrderDetails.Where(o => o.IsDelete == false))
                .ThenInclude(p => p.ProductColor)
                .FirstOrDefaultAsync(o => o.UserId == userId && !o.IsFinally);

            return View(orders);
        }

        public async Task<IActionResult> DeletefromFavorites(int id)
        {
            var product = await context.ProductReactions.FirstOrDefaultAsync(pr => pr.ProductId == id);

            if (product == null)
                return NotFound();

            product.Reaction = false;

            context.ProductReactions.Update(product);
            await context.SaveChangesAsync();

            return Ok(new
            {
                stutus = 100,
                message = "علاقمندی شما حذف شد"
            });


        }

        public async Task<IActionResult> DeletefromVisits(int id)
        {
            var product = await context.ProductVisits.FirstOrDefaultAsync(pr => pr.ProductId == id);

            if (product == null)
                return NotFound();

            product.Visit = 0;

            context.ProductVisits.Update(product);
            await context.SaveChangesAsync();

            return Ok(new
            {
                stutus = 100,
                message = "بازدید شما حذف شد"
            });


        }
    }
}
