using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Product
{
    public class ClientSideProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "گروه دسته بندی")]
        public int CategoryId { get; set; }

        [Display(Name = "عنوان محصول")]
        public string Title { get; set; }

        [Display(Name = "قیمت محصول")]
        public int Price { get; set; }

        [Display(Name = "توضیحات محصول")]
        public string Description { get; set; }

        [Display(Name = "تصویر محصول")]
        public string Image { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsDelete { get; set; }

        [Display(Name = "تاریخ ایجاد محصول")]
        public DateTime CreateDate { get; set; }
    }
}
