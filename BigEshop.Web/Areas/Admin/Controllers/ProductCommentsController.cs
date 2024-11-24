using BigEshop.Data.Context;
using BigEshop.Domain.Enums.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace BigEshop.Web.Areas.Admin.Controllers
{
	public class ProductCommentsController (BigEshopContext context) : AdminSiteBaseController
	{
		public async Task<IActionResult> Index(int productId)
		{
			if (productId < 0)
				return NotFound();

			var comments = await context.ProductComments.Include(p => p.Product).Where(pc => pc.ProductId == productId).ToListAsync();

			return View(comments);
		}

		public async Task<IActionResult> ConfirmComment(int commentId)
		{
			var comment = await context.ProductComments.FirstOrDefaultAsync(pc => pc.Id == commentId);

			if (comment == null)
				return BadRequest(new
				{
					message = "کامنت مشخص شده پیدا نشد",
					status = 101
				});

			comment.Status = ProductCommentStatus.Confirmed;

			context.ProductComments.Update(comment);
			await context.SaveChangesAsync();


			return Ok(new
			{
                message = "کامنت مد نظر شما تایید شد",
                status = 100
            });
		}

        public async Task<IActionResult> RejectComment(int commentId)
        {
            var comment = await context.ProductComments.FirstOrDefaultAsync(pc => pc.Id == commentId);

            if (comment == null)
                return BadRequest(new
                {
                    message = "کامنت مشخص شده پیدا نشد",
                    status = 101
                });

            comment.Status = ProductCommentStatus.Rejected;

            context.ProductComments.Update(comment);
            await context.SaveChangesAsync();


            return Ok(new
            {
                message = "کامنت مد نظر شما رد شد",
                status = 100
            });
        }

		public async Task<IActionResult> Details(int id)
		{
			var comment = await context.ProductComments.Include(pc => pc.User).FirstOrDefaultAsync(pc => pc.Id == id);

			return View(comment);
		}
    }
}
