using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class SimilarProductViewComponent(BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {
            var similarProducts = await context.Products.Where(p => !p.IsDelete)
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductColors)
                .Include(p => p.ProductReactions)
                .Include(p => p.ProductVisits)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
;
            return View("/Views/Shared/Components/SimilarProduct.cshtml", similarProducts);
        }
    }
}
