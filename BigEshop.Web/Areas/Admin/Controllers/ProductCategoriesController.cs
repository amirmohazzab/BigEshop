using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigEshop.Data.Context;
using BigEshop.Domain.Models.ProductCategory;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.ViewModels.ProductCategory;
using BigEshop.Domain.Shared;

namespace BigEshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductCategoriesController 
        (BigEshopContext _context, IProductCategoryService productCategoryService) 
        : AdminSiteBaseController
    {
        

        public async Task<IActionResult> Index(FilterProductCategoryViewModel filter)
        {
            var model = await productCategoryService.FilterAsync(filter);
            ViewBag.filter = filter.Title;
            return View(model);
        }

        #region Create

        public async Task<IActionResult> Create()
        {
            ViewData["ParentCategories"] = await productCategoryService.GetAllParentsAsync();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ParentCategories"] = await productCategoryService.GetAllParentsAsync();
                return View(model);
            }

            var result = await productCategoryService.CreateAsync(model);

            switch (result)
            {
                case CreateProductCategoryResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.CreateProductCategorySuccessfullyDone;
                    return RedirectToAction(nameof(Index));
            }

            ViewData["ParentCategories"] = await productCategoryService.GetAllParentsAsync();
            return View(model);
        }
        #endregion

        #region Edit

        public async Task<IActionResult> Edit(int id)
        {
            var productCategory = await productCategoryService.GetForEditAsync(id);

            if (productCategory == null)
                return NotFound();

            ViewData["ParentCategories"] = await productCategoryService.GetAllParentsAsync();
            return View(productCategory);

        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateProductCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ParentCategories"] = await productCategoryService.GetAllParentsAsync();
                return View(model);
            }

            var result = await productCategoryService.UpdateAsync(model);

            switch (result)
            {
                case UpdateProductCategoryResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.UpdateProductCategorySuccessfullyDone;
                    return RedirectToAction(nameof(Index));

                case UpdateProductCategoryResult.ProductCategoryNotFound:
                    TempData["ErrorMessage"] = ErrorMessages.ProductCategoryNotFound;
                    return RedirectToAction(nameof(Index));
            }

            ViewData["ParentCategories"] = await productCategoryService.GetAllParentsAsync();
            return View(model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            var productCategory = await productCategoryService.GetByIdAsync(id);

            if (productCategory == null)
                return NotFound();

            ViewData["ParentCategories"] = await productCategoryService.GetAllParentsAsync();
            return View(productCategory);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await productCategoryService.DeleteAsync(id);

            switch (result)
            {
                case DeleteProductCategoryResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.DeleteProductCategorySuccessfullyDone;
                    break;

                case DeleteProductCategoryResult.ProductCategoryNotFound:
                    TempData["ErrorMessage"] = ErrorMessages.ProductCategoryNotFound;
                    break;
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        public async Task<IActionResult> Details(int id)
        {
            var productCategory = await productCategoryService.GetByIdAsync(id);

            if (productCategory == null)
                return NotFound();

            ViewData["ParentCategories"] = await productCategoryService.GetAllParentsAsync();
            return View(productCategory);
        }
    }
}
