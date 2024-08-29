using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BigEshop.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

       
    }
}
