using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Payment
{
    public class ErrorPaymentViewModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string RefId { get; set; }

        public ICollection<Models.Order.OrderDetail> OrderDetail { get; set; }
    }
}
