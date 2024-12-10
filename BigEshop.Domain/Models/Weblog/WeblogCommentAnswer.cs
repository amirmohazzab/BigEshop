using BigEshop.Domain.Models.Common;
using BigEshop.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Weblog
{
    public class WeblogCommentAnswer : BaseEntity<int>
    {
        public int WeblogId { get; set; }

        public int CommentId { get; set; }

        public int UserId { get; set; }

        public string AnswerText { get; set; }

        [ForeignKey("CommentId")]
        public WeblogComment WeblogComment { get; set; }

        public User.User User { get; set; }
    }
}
