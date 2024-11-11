using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Controllers
{
    public class ChatHubController : SiteBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
