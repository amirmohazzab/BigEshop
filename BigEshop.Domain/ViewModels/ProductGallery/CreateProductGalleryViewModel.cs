using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.ProductGallery
{
    public class CreateProductGalleryViewModel
    {
        [Display(Name = "محصول")]
        public int ProductId { get; set; }

        [Display(Name = "عنوان عکس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(255)]
        public string? ImageTitle { get; set; }

        [Display(Name = "عکس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public IFormFile Image { get; set; }

    }

    public enum CreateProductGalleryResult
    {
        Success,
        ProductNotFound
    }
}
