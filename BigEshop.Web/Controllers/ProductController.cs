using BigEshop.Application.Extensions;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using BigEshop.Domain.Enums.Product;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.ViewModels.Product;
using BigEshop.Domain.ViewModels.ProductComment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace BigEshop.Web.Controllers
{
    public class ProductController 
        (IProductService productService,
        IProductCategoryService productCategoryService,
        BigEshopContext context) 
        : SiteBaseController
    {
        [HttpGet("/products")]
        public async Task<IActionResult> Index(ClientSideFilterProductViewModel filter)
        {
            var model = await productService.FilterAsync(filter);

            ViewData["Categories"] = await productCategoryService.GetAllChildCategoriesAsync();

            return View(model);
        }

        [HttpGet("/product-details/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            var product = await productService.GetDetailsAsync(slug);

            if (product == null)
                return NotFound();

            return View(product);
        }

        public async Task<IActionResult> ChangeProductColor(int id)
        {
            var productColor = await context.ProductColors.FirstOrDefaultAsync(p => p.Id == id);

            if (productColor == null)
                return BadRequest("Product Color Not Found");

            return Ok(new
            {
                id = productColor.Id,
                Price = productColor.Price.ToMoney(),
                ColorTitle = productColor.ColorTitle,
                Color = productColor.Color
            });
        }

        public IActionResult CreateProductComment(int id)
        {
            return PartialView("_AddProductComment", new ProductComment()
            {
                ProductId = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductComment(ProductComment model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(new
            //    {
            //        status = 110,
            //        message = "لطفا تمامی اطلاعات را پر کنید"
            //    });
            //}


            await context.ProductComments.AddAsync(new ProductComment()
            {
                ProductId = model.ProductId,
                Advantages = model.Advantages,
                DisAdvantages = model.DisAdvantages,
                Status = ProductCommentStatus.Pending,
                Text = model.Text,
                UserId = User.GetUserId(),
                CreateDate = DateTime.Now
            });

            await context.SaveChangesAsync();

            return Ok(new
            {
                status = 100,
                message = "نظر شما با موفقیت ثبت شد"
            });
        }

        [HttpPost]
        public async Task<IActionResult> LikeAction(int commentId, int productId)
        {
            var userId = User.GetUserId();

            var productCommentReaction = await context.ProductCommentReactions
                .FirstOrDefaultAsync(pcr => pcr.UserId == userId && pcr.ProductId == productId && pcr.CommentId == commentId);

            if (productCommentReaction != null)
            {
                if (productCommentReaction.Type == ProductCommentReactionType.Like)
                {
                    productCommentReaction.Type = ProductCommentReactionType.Dislike;

                    context.ProductCommentReactions.Update(productCommentReaction);
                    await context.SaveChangesAsync();
                }
            }
            else
            {
                ProductCommentReaction newProductCommentReaction = new()
                {
                    ProductId = productId,
                    CommentId = commentId,
                    UserId = userId,
                    Type = ProductCommentReactionType.Like
                };

                await context.ProductCommentReactions.AddAsync(newProductCommentReaction);
                await context.SaveChangesAsync();
            }

            return Ok(new
            {
                stutus = 100,
                message = "علاقمندی شما ثبت شد"
            });
        }

        [HttpPost]
        public async Task<IActionResult> DislikeAction(int productId, int commentId)
        {
            var userId = User.GetUserId();

            var productCommentReaction = await context.ProductCommentReactions
            .FirstOrDefaultAsync(pcr => pcr.UserId == userId && pcr.ProductId == productId && pcr.CommentId == commentId);

            if (productCommentReaction != null)
            {
                if (productCommentReaction.Type == ProductCommentReactionType.Dislike)
                {
                    productCommentReaction.Type = ProductCommentReactionType.Like;

                    context.ProductCommentReactions.Update(productCommentReaction);
                    await context.SaveChangesAsync();
                }
            }
            else
            {
                ProductCommentReaction newProductCommentReaction = new()
                {
                    ProductId = productId,
                    CommentId = commentId,
                    UserId = userId,
                    Type = ProductCommentReactionType.Dislike
                };

                await context.ProductCommentReactions.AddAsync(newProductCommentReaction);
                await context.SaveChangesAsync();
            }

            return Ok(new
            {
                stutus = 100,
                message = "عدم علاقمندی شما ثبت شد"
            });
        }

        public IActionResult CreateProductQuestion(int id)
        {
            return PartialView("_AddProductQuestion", new ProductQuestion()
            {
                ProductId = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductQuestion(ProductQuestion model)
        {
            await context.ProductQuestions.AddAsync(new ProductQuestion()
            {
                ProductId = model.ProductId,
                QuestionText = model.QuestionText,
                CreateDate = model.CreateDate,
                UserId = User.GetUserId()
            });

            await context.SaveChangesAsync();

            return Ok(new
            {
                status = 100,
                message = "پرسش شما با موفقیت ثبت شد"
            });
        }

        public IActionResult CreateAnswerToQuestion(int questionId)
        {
            return PartialView("_AddAnswerToQuestion", new ProductAnswer()
            {
                QuestionId = questionId
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnswerToQuestion(ProductAnswer model)
        {
            await context.ProductAnswers.AddAsync(new ProductAnswer()
            {
                QuestionId = model.QuestionId,
                AnswerText = model.AnswerText,
                CreateDate = model.CreateDate,
                UserId = User.GetUserId()
            });

            await context.SaveChangesAsync();

            return Ok(new
            {
                status = 100,
                message = "پاسخ شما با موفقیت ثبت شد"
            });
        }
    }
}
