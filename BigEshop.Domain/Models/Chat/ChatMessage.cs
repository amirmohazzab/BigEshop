using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Chat
{
    public class ChatMessage
    {
        public int ChatId { get; set; }

        public string? Answer { get; set; }

        public int? AnswerUserId { get; set; }

        public Chat Chat { get; set; }

        public User.User? AnswerUser { get; set; }
    }
}
