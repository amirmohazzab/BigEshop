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

namespace BigEshop.Web.Controllers
{
    public class HomeController (BigEshopContext context) : SiteBaseController
    {
        #region Index

        public IActionResult Index()
        {
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
        public async Task<IActionResult> ShowWeblogs(string search=null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.search = search;
                return View(await context.Weblogs.Where(w => w.IsDelete == false && w.Title.Contains(search)).ToListAsync());
            }

            var weblogs = await context.Weblogs.Where(w => w.IsDelete == false).OrderBy(w => w.CreateDate).ToListAsync();

            ViewBag.search = search;
            return View(weblogs);
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
            return PartialView("_AddWeblogComment", new WeblogComment()
            {
                WeblogId = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateWeblogComment(WeblogComment model)
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

        #endregion

        #region Chat

        public IActionResult Chat()
        {
            return PartialView("_AskQuestion");
        }
        #endregion
    }
}
