using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class LatestProductViewComponent 
        (BigEshopContext context) 
        : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {
            var latestProducts = await context.Products.Where(p => p.CategoryId == categoryId)
                .Include(p => p.ProductCategory).Include(p => p.ProductColors)
                .OrderByDescending(w => w.CreateDate)
                .ToListAsync();

            ViewData["Categories"] = await context
                .ProductCategories.Where(p => p.ParentId != null).ToListAsync();

            return View("/Views/Shared/Components/LatestProduct.cshtml", latestProducts);
        }
    }
}
