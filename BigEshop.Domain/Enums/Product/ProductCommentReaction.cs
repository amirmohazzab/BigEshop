using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Enums.Product
{
    public enum ProductCommentReactionType
    {
        [Display(Name = "می پسندم")]
        Like,

        [Display(Name = "نمی پسندم")]
        Dislike
    }
}
