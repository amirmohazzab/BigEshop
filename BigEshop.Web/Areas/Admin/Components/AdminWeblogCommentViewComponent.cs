using BigEshop.Data.Context;
using BigEshop.Domain.Models.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Components
{
    public class AdminWeblogCommentViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int weblogId)
        {
            var comments = await context.WeblogComments
                .Include(w => w.User)
                .Where(w => w.WeblogId == weblogId).ToListAsync();

            return View("AdminWeblogComment", comments);
        }
    }
}
