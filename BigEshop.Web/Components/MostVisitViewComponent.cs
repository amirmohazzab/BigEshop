using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class MostVisitViewComponent(BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productVisits = await context.Products
                .Include(p => p.ProductColors)
                .Include(p => p.ProductVisits)
                .Include(p => p.ProductReactions)
                .OrderByDescending(p => p.ProductVisits.FirstOrDefault().Visit).Take(6).ToListAsync();

            return View("MostVisit", productVisits);
        }
    }
}