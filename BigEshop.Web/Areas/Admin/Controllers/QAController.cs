using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Controllers
{
    public class QAController (BigEshopContext context) : AdminSiteBaseController
    {
        public async Task<IActionResult> Index(int productId)
        {
            var qas = await context.Products
                .Include(p => p.ProductQuestions).Include(p => p.ProductAnswers)
                .FirstOrDefaultAsync(p => p.Id == productId);
                            
            return View(qas);
        }
    }
}
