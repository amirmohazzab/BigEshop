using BigEshop.Application.Services.Implementations;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using BigEshop.Domain.Models.Contact;
using BigEshop.Domain.Shared;
using BigEshop.Domain.ViewModels.ContactUs;
using BigEshop.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

            TempData[SuccessMessage] = "???? ?? ?? ??? ?? ?????? ??? ??";

            return RedirectToAction(nameof(Contact));
            

        }

        #endregion

        #region Weblog
        public IActionResult Weblog()
        {
            return View();
        }

        public IActionResult WeblogDetails()
        {
            return View();
        }

        #endregion

        #region Products

        public IActionResult ShowProducts()
        {
            return View();
        }
        #endregion

    }
}
