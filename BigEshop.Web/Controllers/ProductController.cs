using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Controllers
{
    public class ProductController (IProductService productService) : SiteBaseController
    {
        public async Task<IActionResult> Index(ClientSideFilterProductViewModel filter)
        {
            var model = await productService.FilterAsync(filter);
            return View(model);
        }


        public async Task<IActionResult> Details(int id)
        {
            return View();
        }
    }
}
