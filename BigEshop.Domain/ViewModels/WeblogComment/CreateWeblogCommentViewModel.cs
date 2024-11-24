using BigEshop.Domain.Enums.Weblog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.WeblogComment
{
    public class CreateWeblogCommentViewModel
    {
        public int WeblogId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string Text { get; set; }

    }
}
