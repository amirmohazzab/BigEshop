using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.User
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "کلمه عبور فعلی")]
        [MaxLength(400)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "کلمه عبور ")]
        [MaxLength(400)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "تکرار کلمه عبور")]
        [MaxLength(400)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }

    public enum ChangePasswordResult
    {
        Success,
        OldPasswordInvalid,
        Failed
    }
}
