using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Chat
{
    public class ChatMessage
    {
        public string SenderName { get; set; }

        public string Text { get; set; }

        public DateTimeOffset SendAt { get; set; }
    }
}
