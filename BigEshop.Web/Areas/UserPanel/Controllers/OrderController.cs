﻿using Microsoft.AspNetCore.Mvc;

namespace BigEshop.Web.Areas.UserPanel.Controllers
{
    public class OrderController : UserPanelBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
