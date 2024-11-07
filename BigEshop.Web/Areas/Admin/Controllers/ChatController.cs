using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Areas.Admin.Controllers
{
	public class ChatController : AdminSiteBaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
