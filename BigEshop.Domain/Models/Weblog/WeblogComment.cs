using BigEshop.Domain.Enums.Product;
using BigEshop.Domain.Enums.Weblog;
using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Weblog
{
    public class WeblogComment : BaseEntity<int>
    {
        public int WeblogId { get; set; }

        public int UserId { get; set; }

        public string Text { get; set; }

        public WeblogCommentStatus Status { get; set; }

        public Weblog Weblog { get; set; }

        public User.User User { get; set; }
    }
}
