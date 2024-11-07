using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.ProductFeature
{
    public class CreateProductFeatureViewModel
    {
        [Display(Name = "محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProductId { get; set; }

        [Display(Name = "ویژگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int FeatureId { get; set; }

        [Display(Name = "مقدار ویژگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر بیش از حد مجاز است")]
        public string FeatureValue { get; set; }

        [Display(Name = "ترتیب")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Order { get; set; }

        public string ProductTitle { get; set; }
    }

    public enum CreateProductFeatureResult
    {
        Success,
        ProductNotFound,
        FeatureNotFound
    }
}
