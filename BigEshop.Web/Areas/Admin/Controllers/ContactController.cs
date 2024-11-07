using BigEshop.Data.Context;
using BigEshop.Domain.ViewModels.ContactUs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Controllers
{
	public class ContactController (BigEshopContext context) : AdminSiteBaseController
	{
		public async Task<IActionResult> Index()
		{
			var contacts = await context.Contacts.ToListAsync();
			return View(contacts);
		}

		public async Task<IActionResult> Details(int id)
		{
			var contact = await context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
			return View(contact);
		}

        public IActionResult Answer()
        {
            return View();
        }

		[HttpPost]
        public async Task<IActionResult> Answer(ContactViewModel model)
		{

			return View();
		}
	}
}
