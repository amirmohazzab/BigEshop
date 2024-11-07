using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Order
{
    public class Order : BaseEntity<int>
    {
        public int UserId { get; set; }

        public bool IsFinally { get; set; }

        public User.User? User { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
