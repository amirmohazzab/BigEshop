using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigEshop.Data.Context;
using BigEshop.Domain.Models.Product;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.ViewModels.ProductCategory;
using BigEshop.Domain.ViewModels.Product;
using BigEshop.Domain.Shared;
using BigEshop.Application.Statics;
using SixLabors.ImageSharp;

namespace BigEshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController 
        (IProductService productService, 
        IProductCategoryService productCategoryService,
        IProductGalleryService productGalleryService) 
        : AdminSiteBaseController
    {

        #region Index

        public async Task<IActionResult> Index(AdminSideFilterProductViewModel filter)
        {
            var model = await productService.FilterAsync(filter);
            ViewBag.Filter = filter.Title;
            ViewData["ParentCategories"] = await productCategoryService.GetAllParentsAsync();
            ViewData["ChildCategories"] = await productCategoryService.GetAllChildCategoriesAsync();
            return View(model);
        }

        #endregion

        #region Create

        public async Task<IActionResult> Create()
        {
            ViewData["Categories"] = await productCategoryService.GetAllChildCategoriesAsync();
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Categories"] = await productCategoryService.GetAllChildCategoriesAsync();
                return View(model);
            }
               
            var result = await productService.CreateAsync(model);

            switch (result)
            {
                case CreateProductResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.CreateProductSuccessfullyDone;
                    return RedirectToAction(nameof(Index));
            }

            ViewData["Categories"] = await productCategoryService.GetAllChildCategoriesAsync();
            return View(model);
        }
        #endregion

        #region Edit 

        public async Task<IActionResult> Edit(int id)
        {
            var product = await productService.GetProductForEditAsync(id);

            if (product == null)
                return NotFound();

            ViewData["Categories"] = await productCategoryService.GetAllChildCategoriesAsync();

            return View(product);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Categories"] = await productCategoryService.GetAllChildCategoriesAsync();
                return View(model);
            }

            var result = await productService.UpdateAsync(model);

            switch (result)
            {
                case UpdateProductResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.UpdateProductSuccessfullyDone;
                    return RedirectToAction(nameof(Index));

                case UpdateProductResult.ProductNotFound:
                    TempData[ErrorMessage] = ErrorMessages.ProductNotFound;
                    return RedirectToAction(nameof(Index));
            }

            ViewData["Categories"] = await productCategoryService.GetAllChildCategoriesAsync();
            return View(model);
        }
        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            var product = await productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            ViewData["Categories"] = await productCategoryService.GetAllChildCategoriesAsync();

            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await productService.DeleteAsync(id);

            switch (result)
            {
                case DeleteProductResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.DeleteProductSuccessfullyDone;
                    break;

                case DeleteProductResult.ProductNotFound:
                    TempData["ErrorMessage"] = ErrorMessages.ProductNotFound;
                    break;
            }

            return RedirectToAction(nameof(Index));
        }


        #endregion

        #region Details

        public async Task<IActionResult> Details(int id)
        {
            var product = await productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            ViewData["Categories"] = await productCategoryService.GetAllChildCategoriesAsync();
            return View(product);
        }

        #endregion
    }
}
