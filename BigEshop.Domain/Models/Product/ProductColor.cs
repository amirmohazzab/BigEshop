using BigEshop.Domain.Models.Common;
using BigEshop.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Product
{
    public class ProductColor : BaseEntity<int>
    {
        public int ProductId { get; set; }

        public string Color { get; set; }

        public string? ColorTitle { get; set; }

        public int Price { get; set; }

        public bool IsDelete { get; set; }

        public int? Quantity { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        public ICollection<Order.OrderDetail>? OrderDetails { get; set; }

       
    }
}
