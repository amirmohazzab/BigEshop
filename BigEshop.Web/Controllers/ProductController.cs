using BigEshop.Application.Extensions;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using BigEshop.Domain.Enums.Product;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.ViewModels.Product;
using BigEshop.Domain.ViewModels.ProductComment;
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

        public IActionResult CreateProductComment(int id)
        {
            return PartialView("_AddProductComment", new ProductComment()
            {
                ProductId = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductComment(ProductComment model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    status = 110,
                    message = "لطفا تمامی اطلاعات را پر کنید"
                });
            }


            await context.ProductComments.AddAsync(new ProductComment()
            {
                ProductId = model.ProductId,
                Advantages = model.Advantages,
                DisAdvantages = model.DisAdvantages,
                Status = ProductCommentStatus.Pending,
                Text = model.Text,
                UserId = User.GetUserId(),
                CreateDate = DateTime.Now
            });

            await context.SaveChangesAsync();

            return Ok(new
            {
                status = 100,
                message = "نظر شما با موفقیت قبت شد"
            });
        }
    }
}
