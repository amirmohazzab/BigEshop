using BigEshop.Data.Context;
using BigEshop.Domain.Enums.Product;
using BigEshop.Domain.Enums.Weblog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class WeblogCommentViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int weblogId, int commentId)
        {
            var weblogComments = await context
                .WeblogComments.Where(wc => wc.Status == WeblogCommentStatus.Confirmed && wc.WeblogId == weblogId)
                .Include(w => w.WeblogCommentAnswers)
                .Include(u => u.User)
                .ToListAsync();

            ViewData["WeblogId"] = weblogId;
            ViewData["CommentId"] = commentId;

            return View("WeblogComment", weblogComments);
        }
    }
}
