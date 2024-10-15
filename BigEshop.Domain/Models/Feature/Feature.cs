using BigEshop.Domain.Models.Common;
using BigEshop.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Feature
{
    public class Feature : BaseEntity<int>
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Title { get; set; }

        public bool IsDelete { get; set; }

        public ICollection<ProductFeature>? ProductFeatures { get; set; }
    }
}
