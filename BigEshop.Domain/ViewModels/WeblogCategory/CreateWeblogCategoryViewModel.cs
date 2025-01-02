using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.WeblogCategory
{
    public class CreateWeblogCategoryViewModel
    {
        [Display(Name = "عنوان دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد")]
        public string CategoryTitle { get; set; }
    }

    public enum CreateWeblogCategoryResult
    {
        Success,
        WeblogCategoryNotFound,
        Error
    }
}
