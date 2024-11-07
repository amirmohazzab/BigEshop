using BigEshop.Application.Extensions;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Application.Statics;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.ViewModels.ProductGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
    public class ProductGalleryService 
        (IProductGalleryRepository productGalleryRepository,
        IProductRepository productRepository) 
        : IProductGalleryService
    {
        public async Task<CreateProductGalleryResult> CreateAsync(CreateProductGalleryViewModel model)
        {
            if (!await productRepository.ExistAsync(model.ProductId))
                return CreateProductGalleryResult.ProductNotFound;

            ProductGallery productGallery = new()
            {
               ProductId = model.ProductId,
               CreateDate = DateTime.Now,
               ImageTitle = model.ImageTitle,
            };

            if (model.Image != null)
            {
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);
                model.Image.AddImageToServer(imageName, PathTools.ProductGalleryImagePath);

                productGallery.ImageName = imageName;
            };
            
            await productGalleryRepository.InserAsync(productGallery);
            await productGalleryRepository.SaveAsync();

            return CreateProductGalleryResult.Success;
        }

        public async Task<DeleteProductGalleryResult> DeleteAsync(int id)
        {
            var productGallery = await productGalleryRepository.GetByIdAsync(id);

            if (productGallery == null)
                return DeleteProductGalleryResult.ProductGalleryNotFound;

            productGallery.ImageName.DeleteImage(PathTools.ProductGalleryImagePath);

            productGalleryRepository.Remove(productGallery);
            await productGalleryRepository.SaveAsync();

            return DeleteProductGalleryResult.Success;
        }

        public async Task<FilterProductGalleryViewModel> FilterAsync(FilterProductGalleryViewModel model)
        {
            return await productGalleryRepository.FilterAsync(model);
        }

    }
}
