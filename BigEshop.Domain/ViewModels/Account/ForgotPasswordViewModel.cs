using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        #region Properties

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string Email { get; set; }

        //[Display(Name = "شماره موبایل")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //[MaxLength(15, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        //public string Mobile { get; set; }

        #endregion
    }

    public enum ForgotPasswordResult
    {
        Success,
        MobileNotFound,
        EmailNotFound,
        Error
    }
}
