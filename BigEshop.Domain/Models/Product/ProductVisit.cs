using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Product
{
    public class ProductVisit : BaseEntity<int>
    {
        public int ProductId { get; set; }

        public int UserId { get; set; }

        public int Visit { get; set; } 

        public Product Product { get; set; }

        public User.User User { get; set; }
    }
}
