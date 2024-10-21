using BigEshop.Application.Extensions;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using BigEshop.Domain.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Controllers
{
    public class ProductController 
        (IProductService productService, 
        BigEshopContext context) 
        : SiteBaseController
    {
        [HttpGet("/products")]
        public async Task<IActionResult> Index(ClientSideFilterProductViewModel filter)
        {
            var model = await productService.FilterAsync(filter);
            return View(model);
        }

        [HttpGet("/product-details/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            var product = await productService.GetDetailsAsync(slug);

            if (product == null)
                return NotFound();

            return View(product);
        }

        public async Task<IActionResult> ChangeProductColor(int id)
        {
            var productColor = await context.ProductColors.FirstOrDefaultAsync(p => p.Id == id);

            if (productColor == null)
                return BadRequest("Product Color Not Found");

            return Ok(new
            {
                id = productColor.Id,
                Price = productColor.Price.ToMoney(),
                ColorTitle = productColor.ColorTitle,
                Color = productColor.Color
            });
        }
    }
}
