using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Product
{
    public class ClientProductDetailsViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public string Image { get; set; }

        public string Review { get; set; }

        public string Description { get; set; }

        public string? InfoDescription { get; set; }

        public bool IsFreeShipping { get; set; }

        public string? GuarrantyText { get; set; }

        public Models.ProductCategory.ProductCategory? ProductCategory { get; set; }

        public ICollection<Models.Product.ProductGallery>? ProductGalleries { get; set; }

        public ICollection<Models.Product.ProductFeature>? ProductFeatures { get; set; }

        public ICollection<Models.Product.ProductColor>? ProductColors { get; set; }

        public ICollection<Models.Product.ProductComment>? ProductComments { get; set; }

        public ICollection<Models.Product.ProductCommentReaction>? ProductCommentReactions { get; set; }

        public ICollection<Models.Product.ProductQuestion>? ProductQuestions { get; set; }

        public ICollection<Models.Product.ProductAnswer>? ProductAnswers { get; set; }

        public ICollection<Models.Product.ProductAnswerReaction>? ProductAnswerReactions { get; set; }

        [Display(Name = "مرتب سازی بر اساس")]
        public ClientSideFilterProductCommentOrderBy ProductCommentOrderBy { get; set; }

        [Display(Name = "مرتب سازی بر اساس")]
        public ClientSideFilterProductAnswerOrderBy ProductAnswerOrderBy { get; set; }
    }

    public enum ClientSideFilterProductCommentOrderBy
    {
        [Display(Name = "جدیدترین")]
        CreateDateDesc,

        [Display(Name = "قدیمی ترین")]
        CreateDateAsc,

        [Display(Name = "مفیدترین")]
        MostUseful,
    }

    public enum ClientSideFilterProductAnswerOrderBy
    {
        [Display(Name = "جدیدترین")]
        CreateDateDesc,

        [Display(Name = "قدیمی ترین")]
        CreateDateAsc,

        [Display(Name = "مفیدترین")]
        MostUseful,
    }
}
