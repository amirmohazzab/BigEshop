using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Controllers
{
    public class ChatHubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
