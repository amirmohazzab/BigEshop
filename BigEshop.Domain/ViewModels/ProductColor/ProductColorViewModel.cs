using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.ProductColor
{
    public class ProductColorViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Color { get; set; }

        public string? ColorTitle { get; set; }

        public int Price { get; set; }

        public bool IsDelete { get; set; }

        public int? Quantity { get; set; }

        public DateTime CreateDate { get; set; }

        public string ProductTitle { get; set; }
    }
}
