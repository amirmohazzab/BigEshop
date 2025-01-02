using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class LatestWeblogViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var latestWeblogs = await context.Weblogs
                .Where(w => !w.IsDelete).OrderByDescending(w => w.CreateDate)
                .Take(3)
                .ToListAsync();

            return View("/Views/Shared/Components/LatestWeblog.cshtml", latestWeblogs);
        }
    }
}
