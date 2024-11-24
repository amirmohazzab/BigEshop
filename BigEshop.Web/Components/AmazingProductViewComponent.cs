using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class AmazingProductViewComponent(BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await context.Products.ToListAsync();

            return View("/Views/Shared/Components/AmazingProduct.cshtml", products);
        }
    }
}