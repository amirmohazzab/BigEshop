using BigEshop.Domain.ViewModels.Common;
using BigEshop.Domain.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Weblog
{
    public class ClientSideFilterWeblogViewModel : BasePaging<ClientSideWeblogViewModel>
    {
        [Display(Name = "عنوان")]
        public string? Title { get; set; }

        [Display(Name = "دسته بندی")]
        public int? CategoryId { get; set; }

        [Display(Name = "مرتب سازی بر اساس")]
        public ClientSideFilterWeblogOrderBy WeblogOrderBy { get; set; }
    }

    public enum ClientSideFilterWeblogOrderBy
    {
        [Display(Name = "جدیدترین")]
        CreateDateDesc,

        [Display(Name = "قدیمی ترین")]
        CreateDateAsc,

        [Display(Name = "مفیدترین")]
        MostUseful,

        [Display(Name = "پربازدیدترین")]
        MostVisited,
    }
}
