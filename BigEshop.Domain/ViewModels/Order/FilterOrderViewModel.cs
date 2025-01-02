using BigEshop.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Order
{
    public class FilterOrderViewModel : BasePaging<OrderViewModel>
    {
        [Display(Name = "آدرس")]
        public int AdresId { get; set; }
    }
}
