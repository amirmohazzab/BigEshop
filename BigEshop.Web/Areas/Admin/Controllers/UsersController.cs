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

namespace BigEshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController 
        (IRoleService roleService, IUserService userService,
        BigEshopContext context) 
        : AdminSiteBaseController
	{
       

        // GET: Admin/Users
        public async Task<IActionResult> Index(int pageId = 1, string search="")
        {
            int take = 2;
            int skip = ( pageId - 1) * take;
            // .Where(u => u.FirstName.Contains(search) || u.LastName.Contains(search) || u.Mobile.Contains(search) || u.Email.Contains(search))
            int pageCount = (context.Users.Count() % take == 0) ? context.Users.Count() / take : context.Users.Count() / take + 1;
            var result = await context.Users.Skip(skip).Take(take).ToListAsync();

            

            ViewBag.PageCount = pageCount;
            ViewBag.PageId = pageId;
			ViewBag.search = search;

			return View(result);
        }

        // GET: Admin/Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
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

        // GET: Admin/Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsDelete = true;
                context.Users.Update(user);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return context.Users.Any(e => e.Id == id);
        }
    }
}
