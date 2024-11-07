using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.ProductGallery
{
    public class ProductGalleryViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ImageTitle { get; set; }

        public string ImageName { get; set; }

        public DateTime CreateDate { get; set; }

        public string ProductTitle { get; set; }

        public Models.Product.Product Product { get; set; }
    }
}
