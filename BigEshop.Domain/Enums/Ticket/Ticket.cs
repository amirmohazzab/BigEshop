using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Enums.Ticket
{
	public enum TicketStatus
	{
		[Display(Name = "منتظر بررسی")]
		Pending,

		[Display(Name = "پاسخ داده شده توسط کاربر")]
		UserAnswered,

		[Display(Name = "پاسخ داده شده توسط ادمین")]
		AdminAnswered,

		[Display(Name = "بسته شده")]
		Closed
	}

	public enum TicketPriority
	{
		[Display(Name = "کم")]
		Low,

		[Display(Name = "متوسط")]
		Medium,

		[Display(Name = "مهم")]
		Important
	}

	public enum TicketSection
	{
		[Display(Name = "فنی")]
		Technical,

		[Display(Name = "مالی")]
		Financial,

		[Display(Name = "منابع انسانی")]
		HR
	}
}
