using BigEshop.Domain.Enums.Ticket;
using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Ticket
{
	public class Ticket : BaseEntity<int>
	{
        public int UserId { get; set; }

        public string Title { get; set; }

        public TicketStatus Status { get; set; }

        public TicketPriority Priority { get; set; }

        public TicketSection Section { get; set; }

        public User.User User { get; set; }

        public ICollection<TicketMessage> TicketMessages { get; set; }
    }
}
