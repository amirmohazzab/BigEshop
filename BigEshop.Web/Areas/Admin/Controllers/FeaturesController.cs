using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using BigEshop.Domain.Models.Feature;
using BigEshop.Domain.Shared;
using BigEshop.Domain.ViewModels.Feature;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Controllers
{
    public class FeaturesController 
        (IFeatureService featureService) 
        : AdminSiteBaseController
    {

        #region Index
        public async Task<IActionResult> Index(FilterFeatureViewModel filter)
        {
            var features = await featureService.FilterAsync(filter);
            return View(features);
        }

        #endregion

        #region Create

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await featureService.CreateAsync(model);

            switch (result)
            {
                case CreateFeatureResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.CreateFeatureSuccessfullyDone;
                    return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        #endregion

        #region Update

        public async Task<IActionResult> Edit(int id)
        {
            var feature = await featureService.GetForEditAsync(id);

            if (feature == null)
                return NotFound();

            return View(feature);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateFeatureViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await featureService.UpdateAsync(model);

            switch (result)
            {
                case UpdateFeatureResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.UpdateFeatureSuccessfullyDone;
                    return RedirectToAction(nameof(Index));

                case UpdateFeatureResult.FeatureNotFound:
                    TempData["SuccessMessage"] = ErrorMessages.FeatureNotFound;
                    break;
            }

            return View(model);

        }
        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            var result = await featureService.DeleteAsync(id);

            switch (result)
            {
                case DeleteFeatureResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.DeleteFeatureSuccessfullyDone;
                    return RedirectToAction(nameof(Index));

                case DeleteFeatureResult.FeatureNotFound:
                    TempData["SuccessMessage"] = ErrorMessages.FeatureNotFound;
                    break;
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
