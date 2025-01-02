using BigEshop.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Weblog
{
    public class AdminSideFilterWeblogViewModel : BasePaging<ClientSideWeblogViewModel>
    {
        [Display(Name = "عنوان")]
        public string? Title { get; set; }

        [Display(Name = "دسته بندی")]
        public int? CategoryId { get; set; }
    }
}
