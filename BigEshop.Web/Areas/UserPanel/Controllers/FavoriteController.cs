using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Areas.UserPanel.Controllers
{
    public class FavoriteController : UserPanelBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
