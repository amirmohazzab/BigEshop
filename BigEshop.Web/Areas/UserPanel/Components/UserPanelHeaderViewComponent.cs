using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Areas.UserPanel.Components
{
    public class UserPanelHeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("UserPanelHeader");
        }
    }
}
