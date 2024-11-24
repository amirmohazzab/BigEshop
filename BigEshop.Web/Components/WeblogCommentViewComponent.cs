using BigEshop.Data.Context;
using BigEshop.Domain.Enums.Product;
using BigEshop.Domain.Enums.Weblog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class WeblogCommentViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int weblogId)
        {
            var weblogComments = await context.WeblogComments.Include(w => w.Weblog).Include(u => u.User)
               .Where(wc => wc.Status == WeblogCommentStatus.Confirmed && wc.WeblogId == weblogId)
               .ToListAsync();

            ViewData["WeblogId"] = weblogId;

            return View("WeblogComment", weblogComments);
        }
    }
}
