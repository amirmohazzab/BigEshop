using BigEshop.Domain.Models.Product;
using BigEshop.Domain.ViewModels.ProductGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Interfaces
{
    public interface IProductGalleryRepository
    {
        Task<FilterProductGalleryViewModel> FilterAsync(FilterProductGalleryViewModel model);

        Task InserAsync(ProductGallery productGallery);

        Task SaveAsync();

        Task<ProductGallery> GetByIdAsync(int id);

        void Remove(ProductGallery productGallery);
    }
}
