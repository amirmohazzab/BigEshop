using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Adres
{
    public class UpdateAdresViewModel
    {
        public int Id { get; set; }

        [Display(Name = "کاربر")]
        public int UserId { get; set; }

        [Display(Name = "استان")]
        public string State { get; set; }

        [Display(Name = "شهر")]
        public String City { get; set; }

        [Display(Name = "آدرس")]
        public string DetailAdres { get; set; }

        [Display(Name = "آدرس")]
        public string PlaceName { get; set; }

        [Display(Name = "نوضیخات")]
        public string? Description { get; set; }

        [Display(Name = "تلفن")]
        public string Phone { get; set; }

        [Display(Name = "حذف")]
        public bool IsDelete { get; set; }
    }

    public enum UpdateAdresResult
    {
        Success,
        AdresNotFound
    }
}

