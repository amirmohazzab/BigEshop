using BigEshop.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Product
{
    public class ClientSideFilterProductViewModel: BasePaging<ClientSideProductViewModel>
    {
        [Display(Name ="عنوان")]
        public string? Title { get; set; }

        [Display(Name = "قیمت")]
        public int? Price { get; set; }

        [Display(Name = "دسته بندی")]
        public int? CategoryId { get; set; }

        [Display(Name = "مینیمم قیمت")]
        public int? Min { get; set; }

        [Display(Name = "ماکزیمم قیمت")]
        public int? Max { get; set; }

        [Display(Name = "مرتب سازی بر اساس")]
        public ClientSideFilterProductOrderBy OrderBy { get; set; }
    }

    public enum ClientSideFilterProductOrderBy
    {
        [Display(Name = "جدیدترین")]
        CreateDateDesc,

        [Display(Name = "قدیمی ترین")]
        CreateDateAsc,

        [Display(Name ="پربازدیدترین")]
        MostVisited,

        [Display(Name = "پر فروش ترین")]
        BestSeller
    }
}
