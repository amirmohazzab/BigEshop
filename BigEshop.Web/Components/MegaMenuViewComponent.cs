using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Components
{
    public class MegaMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Shared/Components/MegaMenu.cshtml");
        }
    }
}
