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
                .OrderByDescending(w => w.CreateDate)
                .ToListAsync();

            return View("/Views/Shared/Components/LatestWeblog.cshtml", latestWeblogs);
        }
    }
}
