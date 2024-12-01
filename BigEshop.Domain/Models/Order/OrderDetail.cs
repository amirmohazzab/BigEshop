using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Order
{
    public class OrderDetail : BaseEntity<int>
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int? ProductColorId { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public bool IsDelete { get; set; }

        public Order? Order { get; set; }

        public Product.Product? Product { get; set; }

        public Product.ProductColor? ProductColor { get; set; }
    }
}
