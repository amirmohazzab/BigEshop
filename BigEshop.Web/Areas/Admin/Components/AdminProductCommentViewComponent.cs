using BigEshop.Data.Context;
using BigEshop.Domain.Enums.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BigEshop.Web.Areas.Admin.Components
{
    public class AdminProductCommentViewComponent (BigEshopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var adminProductComment = await context
                .ProductComments
                .Include(p => p.Product)
                .Where(pc => pc.Status == ProductCommentStatus.Pending).ToListAsync();

            return View("AdminProductComment", adminProductComment);
        }
    }
}
