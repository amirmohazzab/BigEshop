using BigEshop.Data.Context;
using BigEshop.Domain.Enums.Weblog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class WeblogCommentAnswerViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int weblogId)
        {
            var weblogCommentAnswers = await context.WeblogCommentAnswers.Include(u => u.User)
               .Where(wca => wca.WeblogId == weblogId)
               .ToListAsync();

            ViewData["WeblogId"] = weblogId;

            return View("WeblogCommentAnswer", weblogCommentAnswers);
        }
    }
}
