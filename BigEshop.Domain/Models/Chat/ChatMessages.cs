using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Chat
{
    public class ChatMessages : BaseEntity<int>
    {
        public int ChatId { get; set; }

        public string SenderName { get; set; }

        public string Text { get; set; }

        public DateTimeOffset SendAt{ get; set; }

        public int SenderId { get; set; }

        public string Message { get; set; }

        public Chat Chat { get; set; }

        public User.User Sender { get; set; }
    }
}
