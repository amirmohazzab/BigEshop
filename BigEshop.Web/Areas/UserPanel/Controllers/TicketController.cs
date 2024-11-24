using BigEshop.Application.Extensions;
using BigEshop.Data.Context;
using BigEshop.Domain.Enums.Ticket;
using BigEshop.Domain.Models.Ticket;
using BigEshop.Domain.ViewModels.Ticket;
using BigEshop.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace BigEshop.Web.Areas.UserPanel.Controllers
{
	public class TicketController (BigEshopContext context) : UserPanelBaseController
	{

        #region Index

        public async Task<IActionResult> Index()
		{
			int userId = User.GetUserId();

			var tickets = await context.Tickets
				.Where(t => t.UserId == userId)
				.OrderByDescending(t => t.CreateDate)
				.ToListAsync();
			return View(tickets);
		}

        #endregion

        #region Details

        public async Task<IActionResult> Details(int id)
		{
            int currentUserId = User.GetUserId();

            var ticket = await context.Tickets
				.Include(t => t.User)
				.Include(t => t.TicketMessages)
				.ThenInclude(t => t.Sender)
				.FirstOrDefaultAsync(t => t.Id == id && t.UserId == currentUserId);

			if (ticket == null)
				return NotFound();

			return View(ticket);
		}

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> Create(ClientCreateTicketViewModel model)
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
        public async Task<IActionResult> Answer(ClientAnswerTicketViewModel model)
		{
			if (!ModelState.IsValid)
			{
				TempData[ErrorMessage] = ModelState.GetModelError();	
				return RedirectToAction(nameof(Details), new { id = model.TicketId });
			}

			int currentUserId = User.GetUserId();

			if(!await context.Tickets
				.AnyAsync(t => t.Id == model.TicketId && t.UserId == currentUserId))
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
