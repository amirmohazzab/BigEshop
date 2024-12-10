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
        public string SenderName { get; set; }

        public DateTime SendAt { get; set; }

        public string Text { get; set; }

        public User.User User { get; set; }

        public ICollection<ChatMessages> ChatMessages { get; set; }



        public string? Answer { get; set; }

        public int? AnswerUserId { get; set; }

        public string Ip { get; set; }

        public User.User? AnswerUser { get; set; }
    }
}
