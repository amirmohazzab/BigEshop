using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.ProductColor
{
    public class UpdateProductColorViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Display(Name = "رنگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string Color { get; set; }

        [Display(Name = "عنوان رنگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string ColorTitle { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }

        [Display(Name = "تعداد")]
        public int? Quantity { get; set; }

        public string ProductTitle { get; set; }


}

    public enum UpdateProductColorResult
    {
        Success,
        ProductNotFound,
        ProductColorNotFound
    }
}
