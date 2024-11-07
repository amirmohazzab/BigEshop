using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Enums.Product
{
    public enum ProductCommentStatus
    {
        [Display(Name = "منتظر بررسی")]
        Pending,

        [Display(Name = "تایید شده")]
        Confirmed,

        [Display(Name = "رد شده")]
        Rejected
    }
}
