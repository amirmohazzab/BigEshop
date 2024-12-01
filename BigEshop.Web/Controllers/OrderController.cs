using BigEshop.Application.Extensions;
using BigEshop.Data.Context;
using BigEshop.Domain.Models.Order;
using BigEshop.Domain.ViewModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Controllers
{
    [Authorize]
    public class OrderController (BigEshopContext context) : SiteBaseController
    {
        [HttpGet("/Cart")]
        public async Task<IActionResult> Index()
        {
            int userId = User.GetUserId();

            var order = await context.Orders
                .Include(O => O.OrderDetails.Where(od => !od.IsDelete))
                .ThenInclude(O => O.Product)
                .Include(O => O.OrderDetails.Where(od => !od.IsDelete))
                .ThenInclude(O => O.ProductColor)
                .FirstOrDefaultAsync(o => o.UserId == userId &&  !o.IsFinally);

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddToOrder(AddToOrderViewModel model)
        {
            var currentUserId = User.GetUserId();

            var order = await context.Orders.FirstOrDefaultAsync(o => o.UserId == currentUserId && !o.IsFinally);

            if (order != null)
            {
                OrderDetail? orderDetail = await context.OrderDetails
                    .FirstOrDefaultAsync(od => od.OrderId == order.Id &&
                     od.ProductId == model.ProductId &&
                     od.ProductColorId == model.ColorId
                    );

                if (orderDetail != null)
                {
                    orderDetail.Quantity++;
                    context.OrderDetails.Update(orderDetail);
                    await context.SaveChangesAsync();
                }
                else
                {
                    int price = default;

                    if (model.ColorId.HasValue)
                    {
                        var productColor = await context.ProductColors
                            .FirstOrDefaultAsync(pc => pc.Id == model.ColorId);

                        price = productColor?.Price ?? 0;
                    }
                    else
                    {
                        var product = await context.Products
                            .FirstOrDefaultAsync(p => p.Id == model.ProductId);

                        price = product?.Price ?? 0;
                    }

                    orderDetail = new OrderDetail()
                    {
                        OrderId = order.Id,
                        CreateDate = DateTime.Now,
                        Price = price,
                        ProductColorId = model.ColorId,
                        ProductId = model.ProductId,
                        Quantity = 1,
                    };

                    await context.OrderDetails.AddAsync(orderDetail);
                    await context.SaveChangesAsync();
                }
            }
            else
            {
                order = new Order()
                {
                    CreateDate = DateTime.Now,
                    IsFinally = false,
                    UserId = currentUserId
                };

                await context.Orders.AddAsync(order);
                await context.SaveChangesAsync();

                int price = default;

                if (model.ColorId.HasValue)
                {
                    var productColor = await context.ProductColors
                        .FirstOrDefaultAsync(pc => pc.Id == model.ColorId);

                    price = productColor?.Price ?? 0;
                }
                else
                {
                    var product = await context.Products
                        .FirstOrDefaultAsync(p => p.Id == model.ProductId);

                    price = product?.Price ?? 0;
                }

                var orderDetail = new OrderDetail()
                {
                    CreateDate = DateTime.Now,
                    OrderId = order.Id,
                    Price = price,
                    ProductColorId = model.ColorId,
                    ProductId = model.ProductId,
                    Quantity = 1
                };

                await context.OrderDetails.AddAsync(orderDetail);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> IncreaseProductQuantity(int id)
        {
            var orderDetail = await context.OrderDetails
                .Include(od => od.Product)
                .Include(od => od.ProductColor)
                .FirstOrDefaultAsync(od => od.Id == id);

            if (orderDetail == null)
                return BadRequest(new
                {
                    status = 101,
                    message = "شناسه ارسال شده صحیح نمی باشد"
                });

            int quantity = orderDetail.ProductColor != null && orderDetail.ProductColor.Quantity.HasValue ?
                orderDetail.ProductColor.Quantity.Value :
                orderDetail.Product.Quantity;

            orderDetail.Quantity++;

            if (orderDetail.Quantity > quantity)
            {
                return BadRequest(new
                {
                    status = 101,
                    message = "تعداد وارد شده مجاز نمی باشد"
                });
            }

            context.OrderDetails.Update(orderDetail);
            await context.SaveChangesAsync();

            return Ok(new
            {
                status = 100,
                message = "عملیات با موفقیت انجام شد",
                orderDetailSum = context.OrderDetails.Sum(o => o.Quantity + o.Price).ToMoney()
            });

        }

        public async Task<IActionResult> DecreaseProductQuantity(int id)
        {
            var orderDetail = await context.OrderDetails.FirstOrDefaultAsync(od => od.Id == id);

            if (orderDetail == null)
                return BadRequest(new
                {
                    status = 101,
                    message = "شناسه ارسال شده صحیح نمی باشد"
                });

            orderDetail.Quantity--;

            if (orderDetail.Quantity <= 0)
                orderDetail.IsDelete = true;

            context.OrderDetails.Update(orderDetail);
            await context.SaveChangesAsync();

            return Ok(new
            {
                status = 100,
                message = "عملیات با موفقیت انجام شد"
            });

        }

        public async Task<IActionResult> DeleteOrderDetails(int id)
        {
            //var orderDetail = await context.OrderDetails.FirstOrDefaultAsync(od => od.Id == id);

            //if (orderDetail == null)
            //    return BadRequest(new
            //    {
            //        status = 101,
            //        message = "شناسه ارسال شده صحیح نمی باشد"
            //    });

            //orderDetail.IsDelete = true;

            //context.OrderDetails.Update(orderDetail);
            //await context.SaveChangesAsync();

            await context.OrderDetails.Where(od => od.Id == id)
                .ExecuteUpdateAsync(sp => sp.SetProperty(od => od.IsDelete, true));

            return Ok(new
            {
                status = 100,
                message = "عملیات با موفقیت انجام شد"
            });
        }

    }
}
