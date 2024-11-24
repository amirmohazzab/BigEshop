using BigEshop.Data.Context;
using BigEshop.Domain.Enums.Weblog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Controllers
{
    public class WeblogCommentsController (BigEshopContext context) : AdminSiteBaseController
    {
        public async Task<IActionResult> Index(int weblogId)
        {
            if (weblogId < 0)
                return NotFound();

            var comments = await context.WeblogComments
                .Include(wc => wc.Weblog).Where(wc => wc.WeblogId == weblogId).ToListAsync();

            return View(comments);
        }

        public async Task<IActionResult> ConfirmWeblogComment(int weblogCommentId)
        {
            var weblogComment = await context.WeblogComments.FirstOrDefaultAsync(wc => wc.Id == weblogCommentId);

            if (weblogComment == null)
                return BadRequest(new
                {
                    status = 101,
                    message = "کامنت پیدا نشد"
                });

            weblogComment.Status = WeblogCommentStatus.Confirmed;

            context.WeblogComments.Update(weblogComment);
            await context.SaveChangesAsync();

            return Ok(new
            {
                status = 100,
                message = "کامنت مد نظر شما تایید شد"
            });
        }

        public async Task<IActionResult> RejectWeblogComment(int weblogCommentId)
        {
            var weblogComment = await context.WeblogComments.FirstOrDefaultAsync(wc => wc.Id == weblogCommentId);

            if (weblogComment == null)
                return BadRequest(new
                {
                    status = 101,
                    message = "کامنت پیدا نشد"
                });

            weblogComment.Status = WeblogCommentStatus.Rejected;

            context.WeblogComments.Update(weblogComment);
            await context.SaveChangesAsync();

            return Ok(new
            {
                status = 100,
                message = "کامنت مد نظر شما رد شد"
            });
        }

        public async Task<IActionResult> Details(int id)
        {
            var comment = await context.WeblogComments.Include(pc => pc.User).FirstOrDefaultAsync(pc => pc.Id == id);

            return View(comment);
        }
    }
}
