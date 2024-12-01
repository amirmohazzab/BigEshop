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

            var favoriteProducts = await context.ProductReactions
                .Include(p => p.Product).Where(pr => pr.UserId == userId && pr.Reaction == true).ToListAsync();

            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var orders = await context.Orders
                .Include(p => p.OrderDetails)
                .ThenInclude(p => p.Product)
                .Where(o => o.UserId == userId && !o.IsFinally).ToListAsync();

            ViewData["User"] = user;
            ViewData["FavoriteProducts"] = favoriteProducts;

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
    }
}
