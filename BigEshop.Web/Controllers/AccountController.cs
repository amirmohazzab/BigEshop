using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.Models.User;
using BigEshop.Domain.Shared;
using BigEshop.Domain.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BigEshop.Web.Controllers
{
    public class AccountController 
        (IAccountService accountService, IUserService userService) 
        : SiteBaseController
    {

        #region Actions

        #region Register

        [HttpGet("/register")]
        public IActionResult Register()
        {
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
                    TempData[SuccessMessage] = ErrorMessages.DuplicatedMobile;
                    break;
            }

            return View(model);
        }

        #endregion


        #region Login

        [HttpGet("/login")]
        public IActionResult Login()
        {
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

                    TempData[SuccessMessage] = "خوش آمدید";
                    return Redirect("/");

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

        #endregion



    }
}
