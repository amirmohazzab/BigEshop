using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Areas.UserPanel.Controllers
{
	public class TicketController : UserPanelBaseController
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Details()
		{
			return View();
		}

		public IActionResult Create()
		{
			return View();
		}
	}
}
