using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Ticket
{
	public class TicketMessage : BaseEntity<int>
	{
        public int TicketId { get; set; }

        public int SenderId { get; set; }

        public string Message { get; set; }

        public Ticket Ticket { get; set; }

        public User.User Sender { get; set; }
    }
}
