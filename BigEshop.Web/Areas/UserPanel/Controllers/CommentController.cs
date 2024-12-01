using BigEshop.Application.Extensions;
using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.UserPanel.Controllers
{
    public class CommentController (BigEshopContext context) : UserPanelBaseController
    {
        public async Task<IActionResult> Index()
        {
            var userId = User.GetUserId();

            var comments = await context.ProductComments
                .Include(p => p.Product).Include(p => p.ProductCommentReactions).Include(p => p.User)
                .Where(pc => pc.UserId == userId).ToListAsync();

            return View(comments);
        }
    }
}
