using BigEshop.Application.Extensions;
using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.UserPanel.Controllers
{
    public class FavoriteController (BigEshopContext context) : UserPanelBaseController
    {
        public async Task<IActionResult> Index()
        {
            var userId = User.GetUserId();

            var products = await context.ProductReactions
                .Include(p => p.Product).Where(pr => pr.UserId == userId && pr.Reaction == true).ToListAsync();

            return View(products);
        }
    }
}
