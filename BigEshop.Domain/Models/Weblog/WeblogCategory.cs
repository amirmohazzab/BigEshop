using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Weblog
{
    public class WeblogCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name ="عنوان دسته بندی")]
        public string CategoryName { get; set; }

        public ICollection<Weblog>? Weblogs { get; set; }
    }
}
