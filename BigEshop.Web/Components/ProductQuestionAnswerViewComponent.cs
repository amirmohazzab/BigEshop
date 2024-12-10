using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BigEshop.Application.Extensions;

namespace BigEshop.Web.Components
{
    public class ProductQuestionAnswerViewComponent(BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {

            var productQuestionAnswers = await context
                .ProductQuestions.Where(paq => paq.ProductId == productId)
                .Include(p => p.ProductAnswers)
                .ThenInclude(p => p.ProductAnswerReactions)
                .Include(p => p.User).ToListAsync();

            return View("ProductQuestionAnswer", productQuestionAnswers);
        }
    }
}
