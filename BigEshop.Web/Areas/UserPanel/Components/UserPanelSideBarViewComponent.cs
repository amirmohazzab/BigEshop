using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Areas.UserPanel.Components
{
    public class UserPanelSideBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("UserPanelSideBar");
        }
    }
}
