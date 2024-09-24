using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.ProductCategory
{
    public class ProductCategory : BaseEntity<int>
    {
        [MaxLength(150)]
        [Display(Name = "عنوان دسته بندی")]
        public string Title { get; set; }

        public int? ParentId { get; set; }

        public bool IsDelete { get; set; } = false;

        [ForeignKey("ParentId")]
        public ProductCategory? Category { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
