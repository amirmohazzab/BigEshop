using BigEshop.Application.Extensions;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using BigEshop.Domain.Enums.Product;
using BigEshop.Domain.Models.Order;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.ViewModels.Product;
using BigEshop.Domain.ViewModels.ProductAnswer;
using BigEshop.Domain.ViewModels.ProductComment;
using BigEshop.Domain.ViewModels.ProductQuestion;
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
            ViewData["Search"] = filter.Title;

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
                Id = productColor.Id,
                Price = productColor.Price.ToMoney(),
                ColorTitle = productColor.ColorTitle,
                Color = productColor.Color
            });
        }

        public IActionResult CreateProductComment(int id)
        {
            return PartialView("_AddProductComment", new CreateProductCommentViewModel()
            {
                ProductId = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductComment(CreateProductCommentViewModel model)
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

        public async Task<IActionResult> LikeToProductComment(int commentId, int productId)
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

        public async Task<IActionResult> DislikeToProductComment(int productId, int commentId)
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
            return PartialView("_AddProductQuestion", new CreateProductQuestionViewModel()
            {
                ProductId = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductQuestion(CreateProductQuestionViewModel model)
        {
            await context.ProductQuestions.AddAsync(new ProductQuestion()
            {
                ProductId = model.ProductId,
                QuestionText = model.QuestionText,
                CreateDate = DateTime.Now,
                UserId = User.GetUserId()
            });

            await context.SaveChangesAsync();

            return Ok(new
            {
                status = 100,
                message = "پرسش شما با موفقیت ثبت شد"
            });
        }

        public IActionResult CreateProductAnswer(int id)
        {
            return PartialView("_AddProductAnswer", new CreateProductAnswerViewModel()
            {
                QuestionId = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAnswer(CreateProductAnswerViewModel model)
        {
            await context.ProductAnswers.AddAsync(new ProductAnswer()
            {
                QuestionId = model.QuestionId,
                AnswerText = model.AnswerText,
                CreateDate = DateTime.Now,
                UserId = User.GetUserId()
            });

            await context.SaveChangesAsync();

            return Ok(new
            {
                status = 100,
                message = "پاسخ شما با موفقیت ثبت شد"
            });
        }

        public async Task<IActionResult> AddToFavorite(int id)
        {
            var userId = User.GetUserId();

            var productReaction = await context.ProductReactions
                .FirstOrDefaultAsync(p => p.ProductId == id && p.UserId == userId);

            if (productReaction == null)
            {
                productReaction = new ProductReaction()
                {
                    CreateDate = DateTime.Now,
                    UserId = User.GetUserId(),
                    ProductId = id,
                    Reaction = true,
                };

                context.ProductReactions.AddAsync(productReaction);
                await context.SaveChangesAsync();

                return Ok(new
                {
                    stutus = 100,
                    message = "علاقمندی شما ثبت شد"
                });
            }
            else
            {
                if (productReaction.Reaction == true)
                {
                    return BadRequest(new
                    {
                        stutus = 101,
                        message = "محصول در لیست علاقه مندی ها میباشد"
                    });
                }
                else
                {
                    productReaction.Reaction = true;

                    context.ProductReactions.Update(productReaction);
                    await context.SaveChangesAsync();

                    return Ok(new
                    {
                        stutus = 100,
                        message = "علاقمندی شما ثبت شد"
                    });
                }
                    
            }
        }

        public async Task<IActionResult> FilterProductsByCategory(int id)
        {
            var productCategory = await context.Products.Where(p => p.CategoryId == id).ToListAsync();

            if (productCategory == null)
                return BadRequest("Product Category Not Found");

            return Ok(new
            {
                count = productCategory.Count(),
                products = productCategory
            });
        }

        public async Task<IActionResult> AddToProductVisit(int id)
        {
            var userId = User.GetUserId();

            var productVisit = await context.ProductVisits
                .FirstOrDefaultAsync(p => p.ProductId == id && p.UserId == userId);

            if (productVisit == null)
            {
                productVisit = new ProductVisit()
                {
                    CreateDate = DateTime.Now,
                    UserId = User.GetUserId(),
                    ProductId = id,
                    Visit = 1
                };

                await context.ProductVisits.AddAsync(productVisit);
                await context.SaveChangesAsync();

                return Ok(new
                {
                    stutus = 100,
                    message = "بازدید شما ثبت شد"
                });
            }
            else
            {
                productVisit.Visit++;

                context.ProductVisits.Update(productVisit);
                await context.SaveChangesAsync();

                return Ok(new
                {
                    stutus = 100,
                    message = "یازدید دوباره شما ثبت شد"
                });
            }
        }
    }
}
