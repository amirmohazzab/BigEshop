using BigEshop.Data.Context;
using BigEshop.Domain.Enums.Product;
using BigEshop.Domain.ViewModels.ProductComment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class ProductCommentViewComponent 
        (BigEshopContext context) 
        : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var productComments = await context.ProductComments
                .Include(pcr => pcr.ProductCommentReactions).Include(pcr => pcr.User)
                .Where(pc => pc.Status == ProductCommentStatus.Confirmed && pc.ProductId == productId)
                .ToListAsync();

            //var query = context.ProductComments
            //    .Include(pcr => pcr.ProductCommentReactions).Include(pcr => pcr.User)
            //    .Where(pc => pc.Status == ProductCommentStatus.Confirmed && pc.ProductId == productId)
            //    .AsQueryable();

            //if (ClientSideFilterProductCommentOrderBy.CreateDateDesc)
            //        break;

            //    case ClientSideFilterProductCommentOrderBy.MostUseful:
            //        break;
            //}

            return View("/Views/Shared/Components/ProductComment.cshtml", productComments);
        }
    }
}
