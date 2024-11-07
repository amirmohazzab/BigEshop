using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.Shared;
using BigEshop.Domain.ViewModels.ProductGallery;
using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Areas.Admin.Controllers
{
    public class ProductGalleriesController 
        (IProductGalleryService productGalleryService) 
        : AdminSiteBaseController
    {
        #region Index
        public async Task<IActionResult> Index(FilterProductGalleryViewModel filter)
        {
            var features = await productGalleryService.FilterAsync(filter);
            return View(features);
        }

        #endregion

        #region Create

        public IActionResult Create(int productId, string productTitle)
        {
            return View(new CreateProductGalleryViewModel()
            {
                ProductId = productId,
                ProductTitle = productTitle
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductGalleryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await productGalleryService.CreateAsync(model);

            switch (result)
            {
                case CreateProductGalleryResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.CreateProductGallerySuccessfullyDone;
                    return RedirectToAction(nameof(Index), new { productId = model.ProductId });

                case CreateProductGalleryResult.ProductNotFound:
                    TempData["SuccessMessage"] = ErrorMessages.ProductGalleryNotFound;
                    break;
            }

            return View(model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id, int productId)
        {
            var result = await productGalleryService.DeleteAsync(id);

            switch (result)
            {
                case DeleteProductGalleryResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.DeleteProductGallerySuccessfullyDone;
                    break;

                case DeleteProductGalleryResult.ProductGalleryNotFound:
                    TempData["SuccessMessage"] = ErrorMessages.ProductGalleryNotFound;
                    break;
            }

            return RedirectToAction(nameof(Index), new { productId = productId });
        }
        #endregion
    }
}
