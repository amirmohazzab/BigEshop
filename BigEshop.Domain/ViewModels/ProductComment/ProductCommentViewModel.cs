using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.ProductComment
{
    public class ProductCommentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نام محصول")]
        public int ProductId { get; set; }

        [Display(Name = "ارسال کننده نظر")]
        public int? UserId { get; set; }

        [Display(Name = "متن")]
        public string Text { get; set; }

        [Display(Name = "مزایا")]
        public string Advantages { get; set; }

        [Display(Name = "معایب")]
        public string DisAdvantages { get; set; }
    }
}
