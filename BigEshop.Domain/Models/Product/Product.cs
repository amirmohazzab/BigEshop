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
    public class Product : BaseEntity<int>
    {
        [Display(Name = "گروه محصول")]
        public int CategoryId { get; set; }

        [Display(Name = "عنوان محصول")]
        public string Title { get; set; }

        [Display(Name = "قیمت محصول")]
        public int Price { get; set; }

        [Display(Name = "توضیحات محصول")]
        public string Description { get; set; }

        [Display(Name = "تصویر محصول")]
        public string Image { get; set; }

        [Display(Name = "حذف محصول")]
        public bool IsDelete { get; set; }

        [ForeignKey("CategoryId")]
        public ProductCategory.ProductCategory? ProductCategory { get; set; }

        public ICollection<ProductGallery>? ProductGalleries { get; set; }

        public ICollection<ProductFeature>? ProductFeatures { get; set; }
    }
}
