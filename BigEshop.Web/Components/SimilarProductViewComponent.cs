using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class SimilarProductViewComponent(BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {
            var similarProducts = await context.Products
                .Include(p => p.ProductCategory)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
;
            return View("/Views/Shared/Components/SimilarProduct.cshtml", similarProducts);
        }
    }
}
