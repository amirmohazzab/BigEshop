using BigEshop.Data.Context;
using BigEshop.Domain.Enums.Weblog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class WeblogCommentAnswerViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int commentId)
        {
            var weblogCommentAnswers = await context
                .WeblogCommentAnswers.Where(wca => wca.CommentId == commentId)
                .Include(u => u.User)
                .ToListAsync();


            return View("WeblogCommentAnswer", weblogCommentAnswers);
        }
    }
}
