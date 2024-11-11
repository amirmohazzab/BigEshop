using BigEshop.Data.Context;
using BigEshop.Domain.Models.Wallet;
using BigEshop.Domain.ViewModels.Wallet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Controllers
{
    public class WalletController (BigEshopContext context) : AdminSiteBaseController
    {
        public async Task<IActionResult> Index()
        {
            List<Wallet> wallets = await context.Wallets
                .Include(u => u.User)
                .OrderByDescending(w => w.CreateDate)
                .ToListAsync();

            return View(wallets);
        }

        public async Task<IActionResult> ChargeWallet(int userId)
        {
            return PartialView("_ChargeWallet", new AdminChargeWalletViewModel()
            {
                UserId = userId
            });
        }

        [HttpPost]
        public async Task<IActionResult> ChargeWallet(AdminChargeWalletViewModel model)
        {

            if(!ModelState.IsValid)
            {
                return Ok(new
                {
                    status = 101,
                    message = "مقادیر الزامی را وارد کنید"
                });
            }


            await context.Wallets.AddAsync(new Wallet()
            {
                Case = model.Case,
                CreateDate = DateTime.Now,
                Description = model.Description,
                Ip = null,
                OrderId = null,
                Payed = true,
                Price = model.Price,
                RefId = model.RefId,
                Type = model.Type,
                UserId = model.UserId
            });

            await context.SaveChangesAsync()
;
            return Ok(new
            {
                status=100,
                message = "شارژ کیف پول با موفقیت انجام شد."
            });
        }
    }
}
 