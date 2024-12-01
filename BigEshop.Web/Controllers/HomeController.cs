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

namespace BigEshop.Web.Controllers
{
    public class HomeController (BigEshopContext context, IWeblogCategoryService weblogCategoryService) : SiteBaseController
    {
        #region Index

        public async Task<IActionResult> Index()
        {
            ViewData["Categories"] = await context.ProductCategories.Where(p => p.ParentId != null).ToListAsync();
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
            //if (!string.IsNullOrEmpty(search))
            //{
            //    ViewBag.search = search;
            //    return View(await context.Weblogs.Where(w => w.IsDelete == false && w.Title.Contains(search)).ToListAsync());
            //}

            //var weblogs = await context.Weblogs.Where(w => w.IsDelete == false).OrderBy(w => w.CreateDate).ToListAsync();

            //ViewBag.search = search;
            //return View(weblogs);

            ViewData["WeblogCategories"] = await weblogCategoryService.GetAllAsync();
            ViewBag.Title = filter.Title;


            var query = context.Weblogs.Where(p => !p.IsDelete).AsQueryable();

            #region Filter

            if (!string.IsNullOrEmpty(filter.Title))
                query = query.Where(p => p.Title.Contains(filter.Title) || p.Description.Contains(filter.Title));

            if (filter.CategoryId.HasValue)
                query = query.Where(p => p.CategoryId == filter.CategoryId.Value);

            #endregion

            #region OrderBy

            switch (filter.WeblogOrderBy)
            {
                case ClientSideFilterWeblogOrderBy.MostVisited:
                    query = query.OrderByDescending(p => p.WeblogVisits.FirstOrDefault().Visit);
                    break;

                case ClientSideFilterWeblogOrderBy.CreateDateDesc:
                    query = query.OrderByDescending(p => p.CreateDate);
                    break;

                case ClientSideFilterWeblogOrderBy.CreateDateAsc:
                    query = query.OrderBy(p => p.CreateDate);
                    break;

                case ClientSideFilterWeblogOrderBy.MostUseful:
                    query = query.OrderByDescending(p => p.WeblogComments.Count());
                    break;
            }

            #endregion

            await filter.Paging(query.Select(p => new ClientSideWeblogViewModel()
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Title = p.Title,
                Description = p.Description,
                Image = p.Image,
                IsDelete = p.IsDelete,
                CreateDate = p.CreateDate,
                Slug = p.Slug,
                WeblogComments = p.WeblogComments.ToList(),
                WeblogVisits = p.WeblogVisits.ToList()
            }));

            return View(filter);
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
                status = 100,
                message = "??? ??? ?? ?????? ??? ??"
            });
        }

        public IActionResult CreateWeblogCommentAnswer(int id)
        {
            return PartialView("_AddWeblogCommentAnswer", new CreateWeblogCommentAnswerViewModel()
            {
                CommentId = id
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
                status = 100,
                message = "??? ??? ?? ?????? ??? ??"
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
                    stutus = 100,
                    message = "?????? ??? ??? ??"
                });
            }
            else
            {
                weblogVisit.Visit++;

                context.WeblogVisits.Update(weblogVisit);
                await context.SaveChangesAsync();

                return Ok(new
                {
                    stutus = 100,
                    message = "?????? ?????? ??? ??? ??"
                });
            }
        }

        #endregion

        #region Chat

        public IActionResult Chat()
        {
            return PartialView("_AskQuestion");
        }
        #endregion
    }
}
