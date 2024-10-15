using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigEshop.Data.Context;
using BigEshop.Domain.Models.User;
using BigEshop.Domain.Enums.User;
using BigEshop.Application.Security;
using BigEshop.Domain.ViewModels.User;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.Shared;
using BigEshop.Application.Services.Implementations;
using BigEshop.Domain.ViewModels.ProductCategory;

namespace BigEshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController 
        (IRoleService roleService, IUserService userService,
        BigEshopContext context) 
        : AdminSiteBaseController
	{
       

        public async Task<IActionResult> Index(FilterUserViewModel filter)
        {
			var model = await userService.FilterAsync(filter);
			ViewBag.filter = filter.FirstName;
			return View(model);
        }

        #region Create

        public async Task<IActionResult> Create()
        {
            ViewData["Roles"] = await roleService.GetAllAsync();
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminSideCreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Roles"] = await roleService.GetAllAsync();
                return View(model);
            }

            var result = await userService.CreateAsync(model);

            switch (result)
            {
                case AdminSideCreateUserResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.CreateUserSuccessfullyDone;
                    return RedirectToAction(nameof(Index));

                case AdminSideCreateUserResult.MobileDuplicated:
                    TempData["ErrorMessage"] = ErrorMessages.DuplicatedMobile;
                    break;

                case AdminSideCreateUserResult.NotSelectedRole:
                    TempData["ErrorMessage"] = ErrorMessages.NotSelectedRole;
                    break;
            };

            ViewData["Roles"] = await roleService.GetAllAsync();
            return View(model);
        }
        #endregion

        #region Edit

        public async Task<IActionResult> Edit(int id)
        {
            var user = await userService.AdminSideGetForEditAsync(id);

            if (user == null)
                return NotFound();

            ViewData["Roles"] = await roleService.GetAllAsync();
            return View(user);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdminSideEditUserViewModel model)
        {

            if (!ModelState.IsValid)
            {
                ViewData["Roles"] = await roleService.GetAllAsync();
                return View(model);
            }

            var result = await userService.AdminSideUpdateAaync(model);

            switch (result)
            {
                case AdminSideEditUserResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.EditUserSuccessfullyDone;
                    return RedirectToAction(nameof(Index));

                case AdminSideEditUserResult.MobileDuplicated:
                    TempData["ErrorMessage"] = ErrorMessages.DuplicatedMobile;
                    break;

                case AdminSideEditUserResult.NotSelectedRole:
                    TempData["ErrorMessage"] = ErrorMessages.NotSelectedRole;
                    break;

                case AdminSideEditUserResult.UserNotFound:
                    TempData["ErrorMessage"] = ErrorMessages.UserNotFound;
                    break;
            }

            ViewData["Roles"] = await roleService.GetAllAsync();
            return View(model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            var user = await userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            ViewData["Roles"] = await roleService.GetAllAsync();
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var result = await userService.DeleteAsync(id);

            switch (result)
            {
                case AdminSideDeleteUserResult.Success:
                    TempData["SuccessMessage"] = SuccessMessages.DeleteUserSuccessfullyDone;
                    return RedirectToAction(nameof(Index));

                case AdminSideDeleteUserResult.UserNotFound:
                    TempData["ErrorMessage"] = ErrorMessages.UserNotFound;
                    break;
            }
            return RedirectToAction(nameof(Index));
        }

        #endregion

        public async Task<IActionResult> Details(int id)
        {
            var user = await userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            ViewData["Roles"] = await roleService.GetAllAsync();
            return View(user);
        }
        
    }
}
