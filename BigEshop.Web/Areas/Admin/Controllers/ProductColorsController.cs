using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.Shared;
using BigEshop.Domain.ViewModels.ProductColor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Controllers
{
    public class ProductColorsController 
        (IProductColorService productColorService) 
        : AdminSiteBaseController
    {
        #region Index
        public async Task<IActionResult> Index(FilterProductColorViewModel filter)
        {
            var model = await productColorService.FilterAsync(filter);

            ViewData["ProductId"] = model.ProductId;

            return View(model);
        }

        #endregion

        #region Create

        public IActionResult Create(int productId)
        {
            return View(new CreateProductColorViewModel()
            {
                ProductId = productId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductColorViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await productColorService.CreateAsync(model);

            switch (result)
            {
                case CreateProductColorResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.CreateProductColorSuccessfullyDone;
                    return RedirectToAction(nameof(Index), new { productId = model.ProductId});

                case CreateProductColorResult.ProductNotFound:
                    TempData[ErrorMessage] = ErrorMessages.ProductNotFound;
                    break;

                case CreateProductColorResult.ExistProductColor:
                    TempData[ErrorMessage] = ErrorMessages.ExistProductColor;
                    break;
            }

            return View(model);
        }
        #endregion

        #region Update

        public async Task<IActionResult> Edit(int id)
        {
            var productColor = await productColorService.GetForEditAsync(id);

            if (productColor == null)
                return NotFound();

            return View(productColor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductColorViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var result = await productColorService.UpdateAsync(model);

            switch (result)
            {
                case UpdateProductColorResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.UpdateProductColorSuccessfullyDone;
                    return RedirectToAction(nameof(Index), new { productId = model.ProductId });

                case UpdateProductColorResult.ProductNotFound:
                    TempData[ErrorMessage] = ErrorMessages.ProductNotFound;
                    break;

                case UpdateProductColorResult.ProductColorNotFound:
                    TempData[ErrorMessage] = ErrorMessages.ProductColorNotFound;
                    break;
            }

            return View(model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id, int productId)
        {
            var result = await productColorService.DeleteAsync(id);

            switch (result)
            {
                case DeleteProductColorResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.DeleteProductColorSuccessfullyDone;
                    break;

                case DeleteProductColorResult.ProductColorNotFound:
                    TempData[ErrorMessage] = ErrorMessages.ProductColorNotFound;
                    break;
            }

            return RedirectToAction(nameof(Index), new { productId = productId });
        }
        #endregion
    }
}
