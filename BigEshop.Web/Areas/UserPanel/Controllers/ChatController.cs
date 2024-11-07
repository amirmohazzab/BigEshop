using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Areas.UserPanel.Controllers
{
	public class ChatController : UserPanelBaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
