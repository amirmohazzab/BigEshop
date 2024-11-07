using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.ProductComment
{
    public class CreateProductCommentViewModel
    {
        public int ProductId { get; set; }

		public int? UserId { get; set; }

        [Display(Name = "متن")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
		public string Text { get; set; }

		[Display(Name = "مزایا")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
		public string Advantages { get; set; }

		[Display(Name = "معایب")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
		public string DisAdvantages { get; set; }
    }
}
