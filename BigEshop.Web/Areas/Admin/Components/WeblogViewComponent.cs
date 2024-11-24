using BigEshop.Data.Context;
using BigEshop.Domain.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Components
{
    public class WeblogViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var weblogs = await context.Weblogs
                .Where(w => w.IsDelete == false)
                .ToListAsync();

            return View("Weblog", weblogs);
        }
    }
}
