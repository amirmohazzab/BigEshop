using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class CategorizedWeblogViewComponent(BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {
            var categorizedWeblog = await context.Weblogs.Where(w => !w.IsDelete)
                .Include(w => w.WeblogComments)
                .Include(w => w.WeblogVisits)
                .Where(w => w.CategoryId == categoryId)
                .OrderByDescending(w => w.CreateDate)
                .ToListAsync();

            return View("/Views/Shared/Components/CategorizedWeblog.cshtml", categorizedWeblog);
        }
    }
}