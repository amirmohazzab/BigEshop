using BigEshop.Data.Context;
using BigEshop.Domain.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Components
{
    public class WeblogViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var weblogs = await context.Weblogs.Where(w => !w.IsDelete)
                .Include(w => w.WeblogVisits.Where(p => p.Visit > 3))
                .OrderByDescending(p => p.WeblogVisits.FirstOrDefault().Visit)
                .ToListAsync();

            return View("Weblog", weblogs);
        }
    }
}
