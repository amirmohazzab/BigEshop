using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class CategoryViewComponent(BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoriess = await context.ProductCategories.ToListAsync();

            return View("/Views/Shared/Components/Category.cshtml", categoriess);
        }
    }
}