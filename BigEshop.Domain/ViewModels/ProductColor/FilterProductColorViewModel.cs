using BigEshop.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.ProductColor
{
    public class FilterProductColorViewModel : BasePaging<ProductColorViewModel>
    {
        [Display(Name = "قیمت")]
        public int? Price { get; set; }

        [Display(Name = "عنوان رنگ")]
        public string ColorTitle { get; set; }

        public int ProductId { get; set; }


    }
}
