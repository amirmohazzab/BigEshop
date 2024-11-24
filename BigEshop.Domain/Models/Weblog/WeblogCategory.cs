using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Weblog
{
    public class WeblogCategory : BaseEntity<int>
    {
        [Display(Name ="عنوان دسته بندی")]
        public string CategoryTitle { get; set; }

        public bool IsDelete { get; set; }

        public ICollection<Weblog>? Weblogs { get; set; }
    }
}
