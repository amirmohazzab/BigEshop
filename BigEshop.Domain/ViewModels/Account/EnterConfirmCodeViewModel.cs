using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Account
{
    public class EnterConfirmCodeViewModel
    {
        [Display(Name = "کد تایید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(12, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string ConfirmCode { get; set; }
    }

    public enum EnterConfirmCodeResult
    {
        Success,
        Error
    }
}
