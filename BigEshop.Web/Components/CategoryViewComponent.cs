using BigEshop.Application.Services.Implementations;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class CategoryViewComponent(IProductCategoryService productCategoryService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await productCategoryService.GetAllChildCategoriesAsync();

            return View("/Views/Shared/Components/Category.cshtml", categories);
        }
    }
}