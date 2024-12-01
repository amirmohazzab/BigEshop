using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Order
{
    public class AddToOrderViewModel
    {
        public int ProductId { get; set; }

        public int? ColorId { get; set; }
    }
}
