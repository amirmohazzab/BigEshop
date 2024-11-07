using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Areas.UserPanel.Controllers
{
    public class AddressController : UserPanelBaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
