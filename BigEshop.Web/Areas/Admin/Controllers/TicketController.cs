using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Areas.Admin.Controllers
{
	public class TicketController : AdminSiteBaseController
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Details()
		{
			return View();
		}

		public IActionResult Answer()
		{
			return View();
		}
	}
}
