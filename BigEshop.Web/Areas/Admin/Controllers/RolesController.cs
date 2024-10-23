using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigEshop.Data.Context;
using BigEshop.Domain.Models.User;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.ViewModels.Role;
using BigEshop.Domain.Shared;
using System.Data;

namespace BigEshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController (IRoleService roleService, BigEshopContext context) : AdminSiteBaseController
    {
        #region Index
        public async Task<IActionResult> Index(FilterRoleViewModel filter)
        {
            var model = await roleService.FilterAsync(filter);

            return View(model);
        }
        #endregion

        #region Create

        public async Task<IActionResult> Create()
        {
            ViewData["Permissions"] = await roleService.GetAllPermissionsAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await roleService.CreateAsync(model);

            switch (result)
            {
                case CreateRoleResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.CreateRoleSuccessfullyDone;
                    return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        #endregion

        #region Edit

        public async Task<IActionResult> Edit(int id)
        {
            var role = await roleService.GetRoleForEditAsync(id);

            if (role == null)
                return NotFound();

            ViewData["Permissions"] = await roleService.GetAllPermissionsAsync();
            return View(role);
        }

       
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await roleService.UpdateAsync(model);

            switch (result)
            {
                case UpdateRoleResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.UpdateRoleSuccessfullyDone;
                    return RedirectToAction(nameof(Index));

                case UpdateRoleResult.RoleNotFound:
                    TempData[ErrorMessage] = ErrorMessages.RoleNotFound;
                    break;
            }

            return View(model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            var result = await roleService.DeleteAsync(id);

            switch (result)
            {
                case DeleteRoleResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.DeleteRoleSuccessfullyDone;
                    break;

                case DeleteRoleResult.RoleNotFound:
                    TempData[ErrorMessage] = ErrorMessages.RoleNotFound;
                    break;
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
