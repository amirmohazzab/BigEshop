using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class LatestProductViewComponent(BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var latestProducts = await context.Products
                .Include(p => p.ProductCategory).Include(p => p.ProductColors)
                .OrderByDescending(w => w.CreateDate)
                .ToListAsync();

            return View("/Views/Shared/Components/LatestProduct.cshtml", latestProducts);
        }
    }
}
