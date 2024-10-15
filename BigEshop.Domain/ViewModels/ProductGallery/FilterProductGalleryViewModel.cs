using BigEshop.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.ProductGallery
{
    public class FilterProductGalleryViewModel : BasePaging<ProductGalleryViewModel>
    {
        [Display(Name = "عنوان عکس")]
        public string? ImageTitle { get; set; }

        public int? ProductId { get; set; }
    }
}
