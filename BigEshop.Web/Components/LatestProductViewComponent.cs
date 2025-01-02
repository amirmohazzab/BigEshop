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
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["Mobile"] = await context
                .Products.Include(p => p.ProductColors).Where(p => p.CategoryId == 2 && !p.IsDelete).ToListAsync();

            ViewData["Laptop"] = await context
               .Products.Include(p => p.ProductColors).Where(p => p.CategoryId == 4 && !p.IsDelete).ToListAsync();

            ViewData["Tablet"] = await context
               .Products.Include(p => p.ProductColors).Where(p => p.CategoryId == 5 && !p.IsDelete).ToListAsync();

            var categories = await context
               .ProductCategories.Where(p => p.ParentId != null && !p.IsDelete).ToListAsync();

            return View("/Views/Shared/Components/LatestProduct.cshtml", categories);
        }
    }
}
