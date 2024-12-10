using BigEshop.Application.Extensions;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using BigEshop.Domain.Enums.Wallet;
using BigEshop.Domain.Models.Wallet;
using BigEshop.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BigEshop.Domain.DTOs.NovinoPay;

namespace BigEshop.Web.Areas.UserPanel.Controllers
{
    public class WalletController 
        (BigEshopContext context)
        : UserPanelBaseController
    {
        public async Task<IActionResult> Index()
        {
            int userId = User.GetUserId();

            List<Wallet> wallets = await context.Wallets
                .Where(w => w.UserId == userId)
                .OrderByDescending(w => w.CreateDate)
                .ToListAsync();

            int creditorAmount = await context.Wallets
                .Where(w => w.UserId == userId && w.Payed && w.Type == TransactionType.Creditor)
                .SumAsync(w => w.Price);

            int depositeAmount = await context.Wallets
                .Where(w => w.UserId == userId && w.Payed && w.Type == TransactionType.Deposite)
                .SumAsync(w => w.Price);

            ViewData["BalanceAmount"] = depositeAmount - creditorAmount;

            return View(wallets);
        }

        [HttpPost]
        public async Task<IActionResult> ChargeWallet(int price)
        {
            if (price < 1000)
            {
                TempData[ErrorMessage] = "مبلغ وارد شده معتبر نمی باشد";
                return RedirectToAction(nameof(Index));
            };

            var wallet = new Wallet()
            {
                Case = TransactionCase.ChargeWallet,
                CreateDate = DateTime.Now,
                Description = "شارژ کیف پول",
                OrderId = null,
                Payed = false,
                Price = price,
                RefId = null,
                Type = TransactionType.Deposite,
                UserId = User.GetUserId(),
                Ip = HttpContext.GetUserIp()
            };

            await context.Wallets.AddAsync(wallet);

            await context.SaveChangesAsync();

            return RedirectToAction("StartPayByNovino", "Payment", new { area = "", walletId = wallet.Id });

        }
    }
}
