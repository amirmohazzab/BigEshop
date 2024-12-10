using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Payment
{
    public class SuccessPaymentViewModel
    {
        public string Message { get; set; }

        public string RefId { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
