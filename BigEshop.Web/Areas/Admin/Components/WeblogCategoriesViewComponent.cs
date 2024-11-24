using BigEshop.Data.Context;
using BigEshop.Domain.Models.Weblog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Components
{
    public class WeblogCategoriesViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var weblogCategories = await context.WeblogCategories
                .Include(wc => wc.Weblogs)
                .Where(wcc => wcc.IsDelete == false)
                .ToListAsync();

            return View("WeblogCategories", weblogCategories);
        }
    }
}
