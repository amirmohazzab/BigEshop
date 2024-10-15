using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Product
{
    public class ProductGallery : BaseEntity<int>
    {
        public int ProductId { get; set; }

        [Display(Name ="عنوان عکس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(255)]
        public string ImageTitle { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(255)]
        public string? ImageName { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
