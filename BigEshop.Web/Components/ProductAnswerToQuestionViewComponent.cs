using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class ProductAnswerToQuestionViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int productId, int questionId)
        {
            var productAnswerToQuestions = await context.ProductAnswers
                .Where(paq => paq.ProductId == productId && paq.QuestionId == questionId).ToListAsync();

            return View("ProductAnswerToQuestion", productAnswerToQuestions);
        }
    }
}

