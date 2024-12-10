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
            //ViewData["Watch"] = await context
            //    .Products.Where(p => p.CategoryId == 8).ToListAsync();

            //ViewData["Mobiles"] = await context
            //   .Products.Where(p => p.CategoryId == 7).ToListAsync();

            //ViewData["Tablets"] = await context
            //   .Products.Where(p => p.CategoryId == 6).ToListAsync();

            var categories = await context
               .ProductCategories.Where(p => p.ParentId != null).ToListAsync();

            return View("/Views/Shared/Components/LatestProduct.cshtml", categories);
        }
    }
}
