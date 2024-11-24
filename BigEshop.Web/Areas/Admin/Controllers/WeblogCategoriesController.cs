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
        public async Task<IActionResult> Index()
        {
            var weblogCategories = await context.WeblogCategories.ToListAsync();

            return View(weblogCategories);
        }

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

            WeblogCategory weblogCategory = new()
            {
                CategoryTitle = model.CategoryTitle,
                CreateDate = DateTime.Now,
                IsDelete = false
            };

            await context.WeblogCategories.AddAsync(weblogCategory);
            await context.SaveChangesAsync();

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

            var result = await weblogCategoryService.UpdateAsync(model);

            switch (result)
            {
                case UpdateWeblogCategoryResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.UpdateProductCategorySuccessfullyDone;
                    return RedirectToAction(nameof(Index));

                case UpdateWeblogCategoryResult.WeblogCategoryNotFound:
                    TempData["ErrorMessage"] = ErrorMessages.ProductCategoryNotFound;
                    return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var weblogCategory = await context.WeblogCategories.FirstOrDefaultAsync(wc => wc.Id == id);

            if (weblogCategory == null)
                return NotFound();

            weblogCategory.IsDelete = true;

            context.WeblogCategories.Update(weblogCategory);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}
