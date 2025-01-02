using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.User;
using BigEshop.Domain.Shared;
using BigEshop.Domain.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;

namespace BigEshop.Web.Controllers
{
    public class AccountController 
        (IAccountService accountService, IUserService userService, IUserRoleRepository userRoleRepository) 
        : SiteBaseController
    {

        #region Actions

        #region Register

        [HttpGet("/register")]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home", new { area = "UserPanel"});

            return View();
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
                return View(model);

            #endregion

            RegisterResult result = await accountService.RegisterAsync(model);

            switch (result)
            {
                case RegisterResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.RegisterSuccessfullyDone;
                    return RedirectToAction("Login");

                case RegisterResult.MobileDuplicated:
                    TempData[ErrorMessage] = ErrorMessages.DuplicatedMobile;
                    break;
            }

            return View(model);
        }

        #endregion

        #region Login

        [HttpGet("/login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home", new { area = "" });

            return View();
        }


        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
                return View(model);

            #endregion

            LoginResult result = await accountService.LoginAsync(model);

            switch (result)
            {
                case LoginResult.Success:
                    User? user = await userService.GetByMobileAsync(model.Mobile);

                    if (user == null)
                    {
                        TempData[ErrorMessage] = ErrorMessages.UserNotFound;
                        return View(model);
                    }

                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.MobilePhone, model.Mobile),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    };

                    ClaimsIdentity claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(claimIdentity);

                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(claimPrincipal, properties);

                    var roleList = await userRoleRepository.GetRoleIdsAsync(user.Id);

                    if (roleList.Contains(2))
                    {
                        TempData[SuccessMessage] = "به ادمین خوش آمدید";
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }

                    TempData[SuccessMessage] = "خوش آمدید";
                    return RedirectToAction("Index", "Home", new { area = "UserPanel" });

                case LoginResult.UserNotFound:
                    TempData[ErrorMessage] = ErrorMessages.UserNotFound; 
                    break;

                case LoginResult.UserIsBan:
                    TempData[ErrorMessage] = ErrorMessages.UserIsBan;
                    break;

                case LoginResult.UserIsNotActive:
                    TempData[ErrorMessage] = ErrorMessages.UserIsNotActive;
                    break;

            }

            return View(model);
        }

        #endregion

        #region Logout

        [HttpGet("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(Login));
        }

        #endregion

        #region Forgot Password

        [HttpGet("/forgot-password")]
        public IActionResult ForgotPassword()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home", new { area = "" });

            return View();
        }


        [HttpPost("/forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
                return View(model);

            #endregion

            ForgotPasswordResult result = await accountService.ForgotPasswordAsync(model);

            switch (result)
            {
                case ForgotPasswordResult.Success:
                    //TempData["Mobile"] = model.Mobile;
                    TempData["Email"] = model.Email;
                    TempData[SuccessMessage] = SuccessMessages.ForgotPasswordSuccessfullyDone;
                    return RedirectToAction(nameof(ResetPassword));

                case ForgotPasswordResult.MobileNotFound:
                    TempData[ErrorMessage] = ErrorMessages.UserNotFound;
                    return RedirectToAction(nameof(ForgotPassword));

                case ForgotPasswordResult.Error:
                    TempData[ErrorMessage] = ErrorMessages.OperationFailed;
                    return RedirectToAction(nameof(ForgotPassword));
            }

            return View(model);
        }

        #endregion

        #region Reset Password

        [HttpGet("/reset-password")]
        public IActionResult ResetPassword()
        {
            //string mobile = TempData["Mobile"]?.ToString();
            string email = TempData["Email"]?.ToString();

            //if (string.IsNullOrEmpty(mobile))
            //    return NotFound();

            if (string.IsNullOrEmpty(email))
                return NotFound();

            //return View(new ResetPasswordViewModel() { Mobile = mobile});
            return View(new ResetPasswordViewModel() { Email = email });
        }

        [HttpPost("/reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
                return View(model);

            #endregion

            ResetPasswordResult result = await accountService.ResetPasswordAsync(model);

            switch (result)
            {
                case ResetPasswordResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.ResetPasswordSuccessfullyDone;
                    return RedirectToAction(nameof(Login));

                case ResetPasswordResult.UserNotFound:
                    TempData[ErrorMessage] = ErrorMessages.UserNotFound;
                    return RedirectToAction(nameof(ForgotPassword));
            }

            return View(model);
        }

        #endregion

        #endregion

    }
}
