using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Weblog
{
    public class WeblogViewModel
    {
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "دسته بندی")]
        public int CategoryId { get; set; }

        [Display(Name = "متن")]
        public string Description { get; set; }

        [Display(Name = "نصویر")]
        public string Image { get; set; }

        [Display(Name = "Slug")]
        public string Slug { get; set; }

        [Display(Name = "وضعیت حذف")]
        public bool IsDelete { get; set; }

        [Display(Name = "تاریخ ایجاد وبلاگ")]
        public DateTime CreateDate { get; set; }
    }
}
