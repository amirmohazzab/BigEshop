using BigEshop.Application.Extensions;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using BigEshop.Domain.ViewModels.ContactUs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Controllers
{
	public class ContactController 
		(BigEshopContext context,
		IEmailSender emailSender) : AdminSiteBaseController
	{
		public async Task<IActionResult> Index()
		{
			var contacts = await context.Contacts.ToListAsync();
			return View(contacts);
		}

		public async Task<IActionResult> Details(int id)
		{
			var contact = await context.Contacts.Include(c => c.AnswerUser).FirstOrDefaultAsync(c => c.Id == id);

			if (contact == null)
				return NotFound();

			return View(contact);
		}


		[HttpPost]
        public async Task<IActionResult> Answer(AnswerContactViewModel model)
		{
			if(!ModelState.IsValid)
			{
				return Ok(new
				{
					state = 101,
					message = "مقادیر مد نظر را وارد کنید"
				});
			}
			
			var contact = await context.Contacts.FirstOrDefaultAsync(c => c.Id == model.Id);

			if(contact == null)
			{
				return Ok(new
				{
					state = 101,
					message = "تماس یا ما پیدا نشد"
				});
			}

			contact.Answer = model.Answer;
			contact.AnswerUserId = User.GetUserId();

			context.Contacts.Update(contact);
			await context.SaveChangesAsync();

			string body = $@"<h3>پاسخ به تماس با ما با عنوان {contact.Title} به شرح زیر می باشد.</h3>
								<p>پاسخ : {contact.Answer}</p>";

			await emailSender.Send(contact.Email, "پاسخ به تماس با ما", body);

			return Ok(new
			{
				state = 100,
				message = "تماس یا ما پاسخ داده شد"
			});


		}
	}
}
