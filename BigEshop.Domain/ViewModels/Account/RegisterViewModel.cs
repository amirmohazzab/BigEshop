using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Account
{
    public class RegisterViewModel
    {
        #region Properties

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(15, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string Mobile { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        [Compare(nameof(Password), ErrorMessage = "کلمه عبور و تکرار آن یکسان نمی باشد")]
        public string ConfirmPassword { get; set; }

        #endregion
    }

    public enum RegisterResult
    {
        Success,
        MobileDuplicated
    }
}
