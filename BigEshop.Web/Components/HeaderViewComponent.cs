using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Shared/Components/Header.cshtml");
        }
    }
}
