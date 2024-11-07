using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Areas.UserPanel.Controllers
{
    public class CommentController : UserPanelBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
