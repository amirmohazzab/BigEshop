using BigEshop.Application.Services.Implementations;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.Shared;
using BigEshop.Domain.ViewModels.ContactUs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BigEshop.Web.Controllers
{
    public class HomeController (IContactService contactService) : Controller
    {
        #region Index
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Contact
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await contactService.CreateAsync(model);

            switch (result)
            {
                case ContactResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.CreateMessageSuccessfullyDone;
                    return RedirectToAction(nameof(Contact));
            }

            return View(model);
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
