using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Weblog
{
    public class WeblogVisit : BaseEntity<int>
    {
        public int WeblogId { get; set; }

        public int UserId { get; set; }

        public int Visit { get; set; }

        public Weblog Weblog { get; set; }

        public User.User User { get; set; }
    }
}
