using BigEshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Controllers
{
    public class QAController (BigEshopContext context) : AdminSiteBaseController
    {
        public async Task<IActionResult> Index(int productId)
        {
            var qas = await context.ProductQuestions.Include(p => p.ProductAnswers)
                .Include(p => p.Product).Where(p => p.ProductId == productId).ToListAsync();

            return View(qas);
        }
    }
}
