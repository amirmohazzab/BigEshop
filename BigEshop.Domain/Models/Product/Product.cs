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

        [Display(Name ="نقد و بررسی")]
        public string Review { get; set; }

        [Display(Name = "توضیحات محصول")]
        public string Description { get; set; }

        public string? InfoDescription { get; set; }

        [Display(Name = "تصویر محصول")]
        public string Image { get; set; }

        [Display(Name = "حذف محصول")]
        public bool IsDelete { get; set; }

        public bool IsFreeShipping { get; set; }

        public string? GuarrantyText { get; set; }

        public int Quantity { get; set; }

        public string Slug { get; set; }

        [ForeignKey("CategoryId")]
        public ProductCategory.ProductCategory? ProductCategory { get; set; }

        public ICollection<ProductGallery>? ProductGalleries { get; set; }

        public ICollection<ProductFeature>? ProductFeatures { get; set; }

        public ICollection<ProductColor>? ProductColors { get; set; }

        public ICollection<Order.OrderDetail>? OrderDetails { get; set; }

        public ICollection<ProductComment>? ProductComments { get; set; }

        public ICollection<ProductCommentReaction>? productCommentReactions { get; set; }

        public ICollection<ProductQuestion>? ProductQuestions { get; set; }

        public ICollection<ProductAnswer>? ProductAnswers { get; set; }

        public ICollection<ProductReaction>? ProductReactions { get; set; }

        public ICollection<ProductVisit>? ProductVisits { get; set; }

    }
}
