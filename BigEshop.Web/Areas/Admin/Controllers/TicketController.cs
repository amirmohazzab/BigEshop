using BigEshop.Application.Extensions;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Context;
using BigEshop.Domain.Enums.Ticket;
using BigEshop.Domain.Models.Ticket;
using BigEshop.Domain.ViewModels.Ticket;
using BigEshop.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Web.Areas.Admin.Controllers
{
	public class TicketController (BigEshopContext context) : AdminSiteBaseController
	{
        #region Index

        public async Task<IActionResult> Index()
		{
			var tickets = await context.Tickets.Include(t => t.User).ToListAsync();

			return View(tickets);
		}

        #endregion

        #region Details

        public async Task<IActionResult> Details(int id)
		{
            var ticket = await context.Tickets
                .Include(t => t.User)
                .Include(t => t.TicketMessages)
                .ThenInclude(t => t.Sender)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null)
                return NotFound();

            return View(ticket);
        }

        #endregion

        #region Create

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Users"] = await context.Users.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminCreateTicketViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var ticket = new Ticket()
            {
                Priority = model.Priority,
                Section = model.Section,
                Status = TicketStatus.Pending,
                CreateDate = DateTime.Now,
                Title = model.Title,
                UserId = User.GetUserId(),
            };

            await context.Tickets.AddAsync(ticket);
            await context.SaveChangesAsync();
            ;
            await context.TicketMessages.AddAsync(new TicketMessage()
            {
                CreateDate = DateTime.Now,
                Message = model.Message,
                SenderId = User.GetUserId(),
                TicketId = ticket.Id
            });

            await context.SaveChangesAsync();

            TempData[SuccessMessage] = "تیکت شما با موفقیت ساخته شد و پیام شما ارسال شد";

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Answer

        [HttpPost]
        public async Task<IActionResult> Answer(AdminAnswerTicketViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = ModelState.GetModelError();
                return RedirectToAction(nameof(Details), new { id = model.TicketId });
            }

            int currentUserId = User.GetUserId();

            if (!await context.Tickets
                .AnyAsync(t => t.Id == model.TicketId))
            {
                TempData[ErrorMessage] = "تیکت مد نظر یافت نشد";
                return RedirectToAction(nameof(Details), new { id = model.TicketId });
            }

            TicketMessage message = new()
            {
                Message = model.Message,
                SenderId = currentUserId,
                TicketId = model.TicketId,
                CreateDate = DateTime.Now
            };

            await context.TicketMessages.AddAsync(message);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = model.TicketId });
        }

        #endregion
    }
}
