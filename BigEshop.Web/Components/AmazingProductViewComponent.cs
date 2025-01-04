using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class AmazingProductViewComponent(BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await context.Products.Where(p => !p.IsDelete)
                .Include(p => p.ProductColors)
                .Include(p => p.ProductVisits)
                .Include(p => p.ProductReactions)
                .OrderByDescending(p => p.CreateDate)
                .Take(10)
                .ToListAsync();

            return View("/Views/Shared/Components/AmazingProduct.cshtml", products);
        }
    }
}