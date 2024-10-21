using BigEshop.Domain.Models.Product;
using BigEshop.Domain.ViewModels.ProductGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Interfaces
{
    public interface IProductGalleryService
    {
        Task<CreateProductGalleryResult> CreateAsync(CreateProductGalleryViewModel model);

        Task<FilterProductGalleryViewModel> FilterAsync(FilterProductGalleryViewModel model);

        Task<DeleteProductGalleryResult> DeleteAsync(int id);
    }
}
