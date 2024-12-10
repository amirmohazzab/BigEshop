using BigEshop.Application.Extensions;
using BigEshop.Application.Services.Implementations;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using BigEshop.Domain.DTOs.NovinoPay;
using BigEshop.Domain.Enums.Wallet;
using BigEshop.Domain.Models.Order;
using BigEshop.Domain.Models.User;
using BigEshop.Domain.Models.Wallet;
using BigEshop.Domain.ViewModels.Payment;
using BigEshop.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Controllers
{
    public class PaymentController 
        (INovinoService novinoService,
        BigEshopContext context) 
        : SiteBaseController
    {
        [Authorize]
        public async Task<IActionResult> StartPayByNovino(int? walletId, int? orderId)
        {
            Wallet? wallet = null;
            Order? order = null;
            int price = 0;
            string invoiceId = "";
            
            if (walletId.HasValue)
            {
                wallet = await context.Wallets.FirstOrDefaultAsync(w => w.Id == walletId);

                if (wallet == null)
                    return NotFound();

                price = wallet.Price * 10;
                invoiceId = $"wallet_{wallet.Id}";
            }
                

            if (orderId.HasValue)
            {
                order = await context.Orders
                 .Include(od => od.OrderDetails)
                 .FirstOrDefaultAsync(o => o.Id == orderId);

                if (order == null)
                    return NotFound();

                price = order.OrderDetails.Sum(od => od.Price * od.Quantity)*10;
                invoiceId = $"order_{order.Id}";
            }

            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == User.GetUserId());

            #region Send Request to gateway payment

            var result = await novinoService.CreateRequestAsync(new NovinoGetPaymentUrlRequestDto()
            {
                MerchantId = "test",
                Amount = price,
                CallbackUrl = $"https://localhost:7023/payment/NovinoCallback?walletId={wallet?.Id}&orderId={order?.Id}",
                Description = "شارژ کیف پول",
                InvoiceId = invoiceId,
                CallbackMethod = "POST",
                Email = user.Email,
                Mobile = user.Mobile,
                Name = $"{user.FirstName} {user.LastName}"
            });

            #endregion
            
            if (result.Status == "100")
            {
                TempData[ErrorMessage] = "عملیات پرداخت با شکست مواجه شد لطفا دقایقی دیگر تلاش کنید";
                return RedirectToAction("Index", "Home");
            }

            #region Save Authority

            if (wallet != null)
            {
                wallet.Authority = result.Data.authority;

                context.Wallets.Update(wallet);
                await context.SaveChangesAsync();

            } 
            else if (order != null)
            {
                wallet = await context.Wallets.FirstOrDefaultAsync(w => w.OrderId == order.Id);

                if (wallet != null)
                {
                    wallet.Authority = result.Data.authority;

                    context.Wallets.Update(wallet);
                    await context.SaveChangesAsync();
                }
            }


            #endregion

            return Redirect($"https://ipg.novinopay.com/StartPay/{result.Data.authority}");
        }

        [HttpPost]
        public async Task<IActionResult> NovinoCallback(string paymentStatus, string authority, string invoiceId, int? walletId, int? orderId)
        {
            if (paymentStatus.ToLower() == "ok")
            {
                string correctAuthority = "";
                int price = 0; 

                if (walletId.HasValue)
                {
                    var wallet = await context.Wallets.FirstOrDefaultAsync(w => w.Id == walletId);

                    if (wallet == null)
                        return NotFound();

                    price = wallet.Price * 10;
                    correctAuthority = wallet.Authority;
                }
                else if (orderId.HasValue != null)
                {
                    var wallet = await context.Wallets.FirstOrDefaultAsync(w => w.OrderId == orderId.Value);

                    if (wallet != null)
                    {
                        price = wallet.Price * 10;
                        correctAuthority = wallet.Authority;
                    }
                }


                var result = await novinoService.VerifyAsync(new NovinoVerifyPaymentRequestDto() {
                    Amount = price,
                    Authority = correctAuthority,
                    MerchantId = "test"
                });

                if (result.Status != "100")
                {
                    return View("ErrorPayment", new ErrorPaymentViewModel()
                    {
                        Message = "خطایی رخ داده است  لطفا از طریق تیکت به پشتیبانی اعلام نمایید",
                    });
                }

                if (walletId.HasValue) {

                    var wallet = await context.Wallets.FirstOrDefaultAsync(w => w.Id == walletId.Value);

                    wallet.Payed = true;
                    wallet.RefId = result.Data.RefId;

                    context.Wallets.Update(wallet);
                    await context.SaveChangesAsync();

                    return View("SuccessPayment", new SuccessPaymentViewModel()
                    {
                        Message = "پرداخت شما با موفقیت انجام شد",
                        RefId = result.Data.RefId
                    });
                }
                else if (orderId.HasValue) {

                    var order = await context.Orders
                        .Include(od => od.OrderDetails).FirstOrDefaultAsync(o => o.Id == orderId.Value);

                    var wallet = await context.Wallets.FirstOrDefaultAsync(w => w.OrderId == order.Id);

                    #region Order

                    order.IsFinally = true;

                    context.Orders.Update(order);
                    await context.SaveChangesAsync();

                    #endregion

                    #region Wallet

                    wallet.Payed = true;
                    wallet.RefId = result.Data.RefId;

                    context.Wallets.Update(wallet);
                    await context.SaveChangesAsync();

                    #endregion

                    #region Add Creditor Wallet

                    var creditorWallet = new Wallet()
                    {
                        Case = TransactionCase.BuyProduct,
                        CreateDate = DateTime.Now,
                        Description = "خرید محصول",
                        OrderId = order.Id,
                        Payed = true,
                        Price = wallet.Price,
                        RefId = null,
                        Type = TransactionType.Creditor,
                        UserId = wallet.UserId,
                        Ip = wallet.Ip
                    };

                    await context.Wallets.AddAsync(creditorWallet);

                    await context.SaveChangesAsync();

                    #endregion

                    return View("SuccessPayment", new SuccessPaymentViewModel() 
                    {
                        Message = "پرداخت شما با موفقیت انجام شد",
                        RefId = result.Data.RefId
                    });
                }

            } 
            else
            {
                return View("ErrorPayment", new ErrorPaymentViewModel()
                {
                    Message = "خطایی رخ داده است  لطفا از طریق تیکت به پشتیبانی اعلام نمایید",
                });
            }

            return View("ErrorPayment", new ErrorPaymentViewModel()
            {
                Message = "خطایی رخ داده است  لطفا از طریق تیکت به پشتیبانی اعلام نمایید",
            });
        }
    }
}
