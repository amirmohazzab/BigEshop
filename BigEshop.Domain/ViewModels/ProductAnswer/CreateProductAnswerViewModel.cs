using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.ProductAnswer
{
    public class CreateProductAnswerViewModel
    {
        public int ProductId { get; set; }

        public int QuestionId { get; set; }

        public int? UserId { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(800, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string AnswerText { get; set; }
    }
}
