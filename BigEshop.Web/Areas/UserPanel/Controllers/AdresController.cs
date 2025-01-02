using BigEshop.Application.Extensions;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using BigEshop.Data.Implementations;
using BigEshop.Domain.Models.Adres;
using BigEshop.Domain.Shared;
using BigEshop.Domain.ViewModels.Adres;
using BigEshop.Domain.ViewModels.ProductAnswer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using System.Runtime.InteropServices;

namespace BigEshop.Web.Areas.UserPanel.Controllers
{
    public class AdresController 
        (IAdresService adresService,
        BigEshopContext context
        ) : UserPanelBaseController
    {
        #region Index
        public async Task<IActionResult> Index()
        {
            var userId = User.GetUserId();
            var adreses = await context.Adreses.Where(a => a.UserId == userId && !a.IsDelete).ToListAsync();

            return View(adreses);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAdresViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Adres adres = new()
            {
                State = model.State,
                City = model.City,
                DetailAdres = model.DetailAdres,
                Description = model.Description,
                PlaceName = model.PlaseName,
                UserId = User.GetUserId(),
                CreateDate = DateTime.Now,
                Phone = model.Phone
            };

            await context.Adreses.AddAsync(adres);
            await context.SaveChangesAsync();

            //var result = await adresService.CreateAsync(model);

            //switch (result)
            //{
            //    case CreateAdresResult.Success:
            //        TempData[SuccessMessage] = SuccessMessages.CreateAdresSuccessfullyDone;
            //        break;

            //    case CreateAdresResult.Error:
            //        TempData[ErrorMessage] = ErrorMessages.Error;
            //        break;
            //}

            return RedirectToAction("Index");
        }

        #endregion

        #region Edit
        public async Task<IActionResult> Edit(int id)
        {
            var adres = await adresService.GetAdresForEditAsync(id);

            return PartialView("_EditAdres", adres);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateAdresViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await adresService.UpdateAsync(model);

            switch(result)
            {
                case UpdateAdresResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.UpdateAdresSuccessfullyDone;
                    return Ok(new
                    {
                        status = 100,
                        message = "آدرس شما با موفقیت ویرایش شد"
                    });

                case UpdateAdresResult.AdresNotFound:
                    TempData[ErrorMessage] = ErrorMessages.AdresNotFound;
                    return BadRequest(new
                    {
                        status = 101,
                        message = "ویرایش آدرس با خطا مواجه شد"
                    });
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            var result = await adresService.DeleteAsync(id);

            switch (result)
            {
                case DeleteAdresResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.DeleteAdresSuccessfullyDone;
                    return Ok(new
                    {
                        status = 100,
                        message = "آدرس شما با موفقیت حذف شد"
                    });

                case DeleteAdresResult.AdresNotFound:
                    TempData[ErrorMessage] = ErrorMessages.AdresNotFound;
                    return BadRequest(new
                    {
                        status = 101,
                        message = "حذف آدرس با خطا مواجه شد"
                    });
            }

            return RedirectToAction("Index");
        }
        #endregion
    }
}
