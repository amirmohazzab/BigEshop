using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Adres
{
    public class AdresViewModel
    {
        [Display(Name = "استان")]
        public string State { get; set; }

        [Display(Name = "شهر")]
        public String City { get; set; }

        [Display(Name = "آدرس")]
        public string DetailAdres { get; set; }

        [Display(Name = "نام محل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PlaseName { get; set; }

        [Display(Name = "نوضیحات")]
        public string? Description { get; set; }

        [Display(Name = "حذف")]
        public bool IsDelete { get; set; }
    }
}
