using BigEshop.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.ProductFeature
{
    public class FilterProductFeatureViewModel : BasePaging<ProductFeatureViewModel>
    {
        [Display(Name = "مقدار ویژگی")]
        public string? FeatureValue { get; set; }

        [Display(Name = "ویژگی")]
        public string? Feature { get; set; }

        public int? ProductId { get; set; }
    }
}
