using BigEshop.Application.Extensions;
using BigEshop.Application.Services.Implementations;
using BigEshop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Areas.UserPanel.Components
{
    public class UserPanelHeaderViewComponent (IUserService userService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int userId = HttpContext.User.GetUserId();

            var user = await userService.GetByIdAsync(userId);

            return View("UserPanelHeader", user);
        }
    }
}
