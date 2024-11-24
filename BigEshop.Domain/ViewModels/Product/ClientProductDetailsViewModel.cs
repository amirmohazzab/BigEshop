using System;
using System.Collections.Generic;
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
    }
}
