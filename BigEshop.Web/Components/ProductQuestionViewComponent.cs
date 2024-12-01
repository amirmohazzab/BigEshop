using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using BigEshop.Application.Extensions;
using BigEshop.Domain.Models.User;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class ProductQuestionViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            //var currentUserId = User.GetUserId();

            var productQuestions = await context.ProductQuestions
                .Where(pq => pq.ProductId == productId)
                .ToListAsync();

            return View("ProductQuestion", productQuestions);
        }
    }
}
