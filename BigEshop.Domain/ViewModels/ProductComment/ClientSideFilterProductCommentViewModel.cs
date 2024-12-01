using BigEshop.Domain.ViewModels.Common;
using BigEshop.Domain.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.ProductComment
{
    public class ClientSideFilterProductCommentViewModel : BasePaging<ProductCommentViewModel>
    {
        [Display(Name = "مرتب سازی بر اساس")]
        public ClientSideFilterProductOrderBy ProductCommentOrderBy { get; set; }
    }

    public enum ClientSideFilterProductCommentOrderBy
    {
        [Display(Name = "جدیدترین")]
        CreateDateDesc,

        [Display(Name = "مفیدترین")]
        MostUseful,
    }
}
