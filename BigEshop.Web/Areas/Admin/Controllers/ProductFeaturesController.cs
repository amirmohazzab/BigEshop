using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.Shared;
using BigEshop.Domain.ViewModels.ProductFeature;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Controllers
{
    public class ProductFeaturesController 
        (IProductFeatureService productFeatureService,
        IFeatureService featureService,
        IProductService productService) 
        : AdminSiteBaseController
    {

        #region Index

        public async Task<IActionResult> Index(FilterProductFeatureViewModel filter)
        {
            var model = await productFeatureService.FilterAsync(filter);

            return View(model);
        }
        #endregion

        #region Create

        public async Task<IActionResult> Create(int productId)
        {
            if (!await productService.ExistAsync(productId))
                return NotFound();

            ViewData["Features"] = await featureService.GetAllAsync();

            return View(new CreateProductFeatureViewModel()
            {
                ProductId = productId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductFeatureViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Features"] = await featureService.GetAllAsync();
                return View(model);
            }

            var result = await productFeatureService.CreateAsync(model);

            switch (result)
            {
                case CreateProductFeatureResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.CreateProductFeatureSuccessfullyDone;
                    return RedirectToAction(nameof(Index));

                case CreateProductFeatureResult.ProductNotFound:
                    TempData["SuccessMessage"] = ErrorMessages.ProductNotFound;
                    break;

                case CreateProductFeatureResult.FeatureNotFound:
                    TempData["SuccessMessage"] = ErrorMessages.FeatureNotFound;
                    break;
            }

            ViewData["Feature"] = await featureService.GetAllAsync();
            return View(model);
        }
        #endregion

        #region Update

        public async Task<IActionResult> Edit(int id)
        {
            var productFeature = await productFeatureService.GetForEditAsync(id);

            if (productFeature == null)
                return NotFound();

            ViewData["Features"] = await featureService.GetAllAsync();

            return View(productFeature);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductFeatureViewModel model)
        {
            if(!ModelState.IsValid)
            {
                ViewData["Features"] = await featureService.GetAllAsync();
                return View(model);
            }

            var result = await productFeatureService.UpdateAsync(model);

            switch (result)
            {
                case UpdateProductFeatureResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.UpdateProductFeatureSuccessfullyDone;
                    return RedirectToAction(nameof(Index));

                case UpdateProductFeatureResult.ProductNotFound:
                    TempData["SuccessMessage"] = ErrorMessages.ProductNotFound;
                    break;

                case UpdateProductFeatureResult.FeatureNotFound:
                    TempData["SuccessMessage"] = ErrorMessages.FeatureNotFound;
                    break;

                case UpdateProductFeatureResult.ProductFeatureNotFound:
                    TempData["SuccessMessage"] = ErrorMessages.ProductFeatureNotFound;
                    break;
            }

            ViewData["Features"] = await featureService.GetAllAsync();
            return View(model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            var result = await productFeatureService.DeleteAsync(id);

            switch (result)
            {
                case DeleteProductFeatureResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.DeleteProductFeatureSuccessfullyDone;
                    return RedirectToAction(nameof(Index));

                case DeleteProductFeatureResult.ProductFeatureNotFound:
                    TempData["SuccessMessage"] = ErrorMessages.ProductFeatureNotFound;
                    break;
            }

            return RedirectToAction(nameof(Index));

        }

        #endregion
    }
}
