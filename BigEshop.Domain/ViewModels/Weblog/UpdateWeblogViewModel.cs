using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Weblog
{
    public class UpdateWeblogViewModel
    {
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "دسته بندی")]
        public int CategoryId { get; set; }

        [Display(Name = "متن")]
        public string Description { get; set; }

        [Display(Name = "تصویر")]
        public IFormFile? NewImage { get; set; }

        public string? ImageName { get; set; }

        [Display(Name = "Slug")]
        public string Slug { get; set; }

        [Display(Name = "حذف")]
        public bool IsDelete { get; set; }
    }

    public enum UpdateWeblogResult
    {
        Success,
        WeblogNotFound,
        SlugDuplicated
    }
}
