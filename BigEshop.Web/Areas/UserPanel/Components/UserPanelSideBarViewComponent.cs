using BigEshop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BigEshop.Application.Extensions;

namespace BigEshop.Web.Areas.UserPanel.Components
{
    public class UserPanelSideBarViewComponent (IUserService userService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int userId = HttpContext.User.GetUserId();

            var user = await userService.GetByIdAsync(userId);

            return View("UserPanelSideBar", user);
        }
    }
}
