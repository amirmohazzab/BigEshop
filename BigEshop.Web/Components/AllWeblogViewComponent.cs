using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class AllWeblogViewComponent(BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allWeblogs = await context.Weblogs
                .OrderByDescending(w => w.CreateDate)
                .ToListAsync();

            return View("/Views/Shared/Components/AllWeblog.cshtml", allWeblogs);
        }
    }
}
