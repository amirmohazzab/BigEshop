using BigEshop.Application.Statics;
using BigEshop.Data.Context;
using BigEshop.Domain.Models.Weblog;
using BigEshop.Domain.ViewModels.Weblog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BigEshop.Application.Extensions;
using BigEshop.Application.Statics;
using BigEshop.Application.Services.Implementations;
using BigEshop.Domain.Models.Product;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.Shared;

namespace BigEshop.Web.Areas.Admin.Controllers
{
	public class WeblogsController 
		(IWeblogService weblogService,
		IWeblogCategoryService weblogCategoryService) : AdminSiteBaseController
	{
		public async Task<IActionResult> Index()
		{
			var weblogs = await weblogService.GetAllAsync();
			return View(weblogs);
		}

		[HttpGet("/add-weblog")]
		public async Task<IActionResult> Create()
		{
			ViewData["Categories"] = await weblogCategoryService.GetAllAsync();
				
			return View();
		}

		[HttpPost("/add-weblog")]
		public async Task<IActionResult> Create(CreateWeblogViewModel model)
		{
			if (!ModelState.IsValid)
			{
				ViewData["Categories"] = await weblogCategoryService.GetAllAsync();

                return View(model);
			}

			var result = await weblogService.CreateAsync(model);

            switch (result)
            {
                case CreateWeblogResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.CreateWeblogSuccessfullyDone;
                    break;

				case CreateWeblogResult.SlugExist:
					TempData[ErrorMessage] = ErrorMessages.SlugExist;
                    break;
            }

            ViewData["Categories"] = await weblogCategoryService.GetAllAsync();

            return RedirectToAction(nameof(Index));
		}

		[HttpGet("/edit-weblog")]
		public async Task<IActionResult> Edit(int id)
		{
			var weblog = await weblogService.GetForEditAsync(id);

			if (weblog == null)
				return NotFound();

			ViewData["Categories"] = await weblogCategoryService.GetAllAsync();

            return View(weblog);
		}

		[HttpPost("/edit-weblog")]
		public async Task<IActionResult> Edit(UpdateWeblogViewModel model)
		{
			if (!ModelState.IsValid)
			{
				ViewData["Categories"] = await weblogCategoryService.GetAllAsync();
                return View(model);
			}

			var result = await weblogService.UpdateAsync(model);

            switch (result)
            {
                case UpdateWeblogResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.UpdateWeblogSuccessfullyDone;
                    return RedirectToAction(nameof(Index));

                case UpdateWeblogResult.WeblogNotFound:
                    TempData[ErrorMessage] = ErrorMessages.WeblogNotFound;
                    return RedirectToAction(nameof(Index));

                case UpdateWeblogResult.SlugDuplicated:
					TempData[ErrorMessage] = ErrorMessages.SlugDuplicated;
                    return RedirectToAction(nameof(Index));
            }

            ViewData["Categories"] = await weblogCategoryService.GetAllAsync();

            return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Details(string slug)
		{
			var weblog = await weblogService.GetDetailsAsync(slug);

			if (weblog == null)
				return NotFound();

			ViewData["Categories"] = await weblogCategoryService.GetAllAsync();

            return View(weblog);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await weblogService.DeleteAsync(id);

			switch (result)
			{
				case DeleteWeblogResult.Success:
					TempData[SuccessMessage] = SuccessMessages.DeleteWeblogSuccessfullyDone;
					break;

				case DeleteWeblogResult.WeblogNotFound:
					TempData[ErrorMessage] = ErrorMessages.WeblogNotFound;
					break;
            }

			return RedirectToAction(nameof(Index));
		}
	}
}
