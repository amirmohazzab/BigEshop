using BigEshop.Application.Services.Implementations;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using BigEshop.Domain.Models.ProductCategory;
using BigEshop.Domain.Models.Weblog;
using BigEshop.Domain.Shared;
using BigEshop.Domain.ViewModels.ProductCategory;
using BigEshop.Domain.ViewModels.WeblogCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Controllers
{
    public class WeblogCategoriesController 
        (IWeblogCategoryService weblogCategoryService,
          BigEshopContext context) 
        : AdminSiteBaseController
    {
        #region Index
        public async Task<IActionResult> Index()
        {
            var weblogCategories = await weblogCategoryService.GetAllAsync();

            return View(weblogCategories);
        }

        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWeblogCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await weblogCategoryService.CreateAsync(model);

            switch (result)
            {
                case CreateWeblogCategoryResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.CreateWeblogCategorySuccessfullyDone;
                    return RedirectToAction(nameof(Index));

                case CreateWeblogCategoryResult.WeblogCategoryNotFound:
                    TempData["ErrorMessage"] = ErrorMessages.WeblogCategoryNotFound;
                    return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var productCategory = await weblogCategoryService.GetForEditAsync(id);

            if (productCategory == null)
                return NotFound();

            return View(productCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateWeblogCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await weblogCategoryService.Update(model);

            switch (result)
            {
                case UpdateWeblogCategoryResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.UpdateWeblogCategorySuccessfullyDone;
                    return RedirectToAction(nameof(Index));

                case UpdateWeblogCategoryResult.WeblogCategoryNotFound:
                    TempData["ErrorMessage"] = ErrorMessages.WeblogCategoryNotFound;
                    return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await weblogCategoryService.DeleteAsync(id);

            switch (result)
            {
                case DeleteWeblogCategoryResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.DeleteWeblogCategorySuccessfullyDone;
                    return RedirectToAction(nameof(Index));

                case DeleteWeblogCategoryResult.WeblogCategoryNotFound:
                    TempData["ErrorMessage"] = ErrorMessages.WeblogCategoryNotFound;
                    return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion

    }
}
