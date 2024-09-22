using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminSiteBaseController : Controller
	{
		protected string SuccessMessage = "SuccessMessage";

		protected string ErrorMessage = "ErrorMessage";

		protected string WarningMessage = "WarningMessage";

		protected string InfoMessage = "InfoMessage";


	}
}
