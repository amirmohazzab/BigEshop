using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Product
{
    public class CreateProductViewModel
    {
        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CategoryId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string Title { get; set; }

        [Display(Name = "Slug")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string Slug { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }

        [Display(Name = "تعداد موجود")]
        public int Quantity { get; set; }

        [Display(Name = "نقد و بررسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Review { get; set; }

        [Display(Name = "تو ضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "متن هشدار")]
        public string? InfoDescription { get; set; }

        [Display(Name = "ارسال رایگان")]
        public bool IsFreeShipping { get; set; }

        [Display(Name = "متن گارانتی")]
        [MaxLength(700, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string? GuarrantyText { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public IFormFile Image { get; set; }

    }

    public enum CreateProductResult
    {
        Success,
        SlugExist
    }
}
