using BigEshop.Application.Services.Implementations;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using BigEshop.Domain.Models.Contact;
using BigEshop.Domain.Models.Weblog;
using BigEshop.Domain.Shared;
using BigEshop.Domain.ViewModels.ContactUs;
using BigEshop.Domain.Enums.Weblog;
using BigEshop.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using BigEshop.Application.Extensions;
using BigEshop.Domain.ViewModels.WeblogComment;
using BigEshop.Domain.ViewModels.Weblog;
using BigEshop.Domain.ViewModels.Product;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.ViewModels.Chat;
using BigEshop.Domain.Models.Chat;

namespace BigEshop.Web.Controllers
{
    public class HomeController 
        (BigEshopContext context, 
        IProductCategoryService productCategoryService,
        IWeblogCategoryService weblogCategoryService,
        IWeblogService weblogService) : SiteBaseController
    {
        #region Index

        public async Task<IActionResult> Index()
        {
            ViewData["Categories"] = await productCategoryService.GetAllChildCategoriesAsync();
            return View();
        }

        #endregion

        #region Contact
        [HttpGet("/contact-us")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("/contact-us")]
        public async Task<IActionResult> Contact(CreateContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await context.Contacts.AddAsync(new Contact()
            {
                Answer = null,
                AnswerUserId = null,
                FullName = model.FullName,
                Mobile = model.Mobile,
                Email = model.Email,
                Title = model.Title,
                Description = model.Description,
                CreateDate = DateTime.Now,
                Ip = HttpContext.Connection.RemoteIpAddress?.ToString(),
                AnswerUser = null
            });

            await context.SaveChangesAsync();

            TempData["SuccessMessage"] = SuccessMessages.CreateContactUsSuccessfullyDone;

            return RedirectToAction(nameof(Contact));
            

        }

        #endregion

        #region Weblog
        public async Task<IActionResult> ShowWeblogs(ClientSideFilterWeblogViewModel filter)
        {
            var model = await weblogService.FilterAsync(filter);

            ViewData["WeblogCategories"] = await weblogCategoryService.GetAllAsync();
            ViewBag.Title = filter.Title;

            return View(model);
        }

        public async Task<IActionResult> WeblogDetails(int id)
        {
            var weblog = await context.Weblogs
                .Include(w => w.WeblogComments).Include(w => w.WeblogCategory)
                .Where(w => w.IsDelete == false).FirstOrDefaultAsync(w => w.Id == id);

            return View(weblog);
        }

        public IActionResult CreateWeblogComment(int id)
        {
            return PartialView("_AddWeblogComment", new CreateWeblogCommentViewModel()
            {
                WeblogId = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateWeblogComment(CreateWeblogCommentViewModel model)
        {
            await context.WeblogComments.AddAsync(new WeblogComment()
            {
                WeblogId = model.WeblogId,
                Status = WeblogCommentStatus.Pending,
                Text = model.Text,
                UserId = User.GetUserId(),
                CreateDate = DateTime.Now
            });

            await context.SaveChangesAsync();

            return Ok(new
            {
                status = 100
            });
        }

        public IActionResult CreateWeblogCommentAnswer(int weblogId, int commentId)
        {
            var currentUserId = User.GetUserId();
            var confirm = context.WeblogComments.Any(p => p.Id == commentId && p.UserId == currentUserId);

            if (confirm)
                return PartialView("_WeblogAlert");

            return PartialView("_AddWeblogCommentAnswer", new CreateWeblogCommentAnswerViewModel()
            {
                WeblogId = weblogId,
                CommentId = commentId
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateWeblogCommentAnswer(CreateWeblogCommentAnswerViewModel model)
        {
            await context.WeblogCommentAnswers.AddAsync(new WeblogCommentAnswer()
            {
                WeblogId = model.WeblogId,
                CommentId = model.CommentId,
                AnswerText = model.AnswerText,
                UserId = User.GetUserId(),
                CreateDate = DateTime.Now
            });

            await context.SaveChangesAsync();

            return Ok(new
            {
                status = 100
            });
        }

        public async Task<IActionResult> AddToWeblogVisit(int id)
        {
            var userId = User.GetUserId();

            var weblogVisit = await context.WeblogVisits
                .FirstOrDefaultAsync(p => p.WeblogId == id && p.UserId == userId);

            if (weblogVisit == null)
            {
                weblogVisit = new WeblogVisit()
                {
                    CreateDate = DateTime.Now,
                    UserId = User.GetUserId(),
                    WeblogId = id,
                    Visit = 1
                };

                await context.WeblogVisits.AddAsync(weblogVisit);
                await context.SaveChangesAsync();

                return Ok(new
                {
                    stutus = 100
                });
            }
            else
            {
                weblogVisit.Visit++;

                context.WeblogVisits.Update(weblogVisit);
                await context.SaveChangesAsync();

                return Ok(new
                {
                    stutus = 100
                });
            }
        }

        #endregion

        public async Task<IActionResult> ShowCategorizedProduct(int id)
        {
            var products = await context.Products
                .Include(p => p.ProductColors)
                .Include(p => p.ProductGalleries)
                .Where(p => p.CategoryId == id).ToListAsync();

            ViewData["Products"] = products;

            return PartialView("_CategorizedProduct");
        }

        #region Chat

        public IActionResult ShowContactModal()
        {
            return PartialView("_AddQuestion");
        }

        [HttpPost]
        public async Task<IActionResult> ShowContactModal(AddChatQuestionViewModel model)
        {
            //await context.Chats.AddAsync(new Chat()
            //{
            //    WeblogId = model.WeblogId,
            //    Status = WeblogCommentStatus.Pending,
            //    Text = model.Text,
            //    UserId = User.GetUserId(),
            //    CreateDate = DateTime.Now
            //});

            await context.SaveChangesAsync();

            return Ok(new
            {
                status = 100,
                message = "??? ??? ?? ?????? ??? ??"
            });
        }
        #endregion
    }
}
