using BigEshop.Application.Extensions;
using BigEshop.Application.Services.Implementations;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using BigEshop.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Components
{
    public class HeaderViewComponent (IUserService userService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            int userId = HttpContext.User.GetUserId();
            var user = await userService.GetByIdAsync(userId);
            ViewData["User"] = user;

            return View("/Views/Shared/Components/Header.cshtml", user);
        }
    }
}
