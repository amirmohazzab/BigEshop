using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class MostSoldOutViewComponent(BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mostSoldOut = await context
                .OrderDetails.Where(od => !od.IsDelete).Include(od => od.Product).OrderByDescending(od => od.Quantity).ToListAsync();

            return View("/Views/Shared/Components/MostSoldOut.cshtml", mostSoldOut);
        }
    }
}