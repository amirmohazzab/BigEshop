using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class ProductQuestionViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var productQuestions = await context.ProductQuestions
                .Where(pq => pq.ProductId == productId).ToListAsync();

            return View("ProductQuestion", productQuestions);
        }
    }
}
