using BigEshop.Domain.Enums.Ticket;
using BigEshop.Domain.Models.Common;
using BigEshop.Domain.Models.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Chat
{
    public class Chat : BaseEntity<int>
    {
        public string SenderName{ get; set; }

        public string Text { get; set; }

        public string Ip { get; set; }

        public ICollection<ChatMessage> ChatMessages { get; set; }
    }
}
