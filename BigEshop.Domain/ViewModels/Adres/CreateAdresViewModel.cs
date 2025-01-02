using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Adres
{
    public class CreateAdresViewModel
    {
        [Display(Name = "کاربر")]
        public int UserId { get; set; }

        [Display(Name = "استان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string State { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public String City { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string DetailAdres { get; set; }

        [Display(Name = "نام محل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PlaseName { get; set; }

        [Display(Name = "نوضیحات")]
        public string? Description { get; set; }

        [Display(Name = "تلفن")]
        public string Phone { get; set; }

        [Display(Name = "حذف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsDelete { get; set; }
    }

    public enum CreateAdresResult
    {
        Success,
        Error
    }
}
