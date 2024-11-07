using BigEshop.Application.Extensions;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.Shared;
using BigEshop.Domain.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BigEshop.Web.Areas.UserPanel.Controllers
{
    public class UserController (IUserService userService) : UserPanelBaseController
    {
        #region Actions


        #region Edit Profile

        public async Task<IActionResult> EditProfile()
        {
            int userId = User.GetUserId();

            EditUserProfileViewModel? model = await userService.GetProfileForEditAsync(userId);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditUserProfileViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
                return View(model);
            #endregion

            model.UserId = User.GetUserId();

            EditUserProfileResult result = await userService.UpdateUserProfileAsync(model);

            switch (result)
            {
                case EditUserProfileResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.UpdateProfileSuccessfullyDone;
                    return RedirectToAction(nameof(EditProfile));

                case EditUserProfileResult.UserNotFound:
                    TempData[ErrorMessage] = ErrorMessages.UserNotFound;
                    return RedirectToAction(nameof(EditProfile));
            }

            return View(model);
        }

        #endregion

        #region Change Password

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel changePassword)
        {
            if (!ModelState.IsValid)
            {
                return View(changePassword);
            }

            int currentUserId = User.GetUserId();

            var result = userService.ChangePassword(currentUserId, changePassword);

            ViewBag.Result = result;

            return View();
        }

        #endregion

        #endregion
    }
}
