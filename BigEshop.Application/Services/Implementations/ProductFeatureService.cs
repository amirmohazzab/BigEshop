using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.ViewModels.ProductFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
    public class ProductFeatureService 
        (IProductFeatureRepository productFeatureRepository,
        IProductRepository productRepository,
        IFeatureRepository featureRepository) 
        : IProductFeatureService
    {
        public async Task<CreateProductFeatureResult> CreateAsync(CreateProductFeatureViewModel model)
        {

            if (!await productRepository.ExistAsync(model.ProductId))
                return CreateProductFeatureResult.ProductNotFound;

            if (!await featureRepository.ExistAsync(model.FeatureId))
                return CreateProductFeatureResult.FeatureNotFound;

            ProductFeature productFeature = new()
            {
                ProductId = model.ProductId,
                FeatureId = model.FeatureId,
                FeatureValue = model.FeatureValue,
                Order = model.Order,
                IsDelete = false,
                CreateDate = DateTime.Now
            };

            await productFeatureRepository.InserAsync(productFeature);
            await productFeatureRepository.SaveAsync();

            return CreateProductFeatureResult.Success;
        }

        public async Task<DeleteProductFeatureResult> DeleteAsync(int id)
        {
            var productFeature = await productFeatureRepository.GetByIdAsync(id);

            if (productFeature == null)
                return DeleteProductFeatureResult.ProductFeatureNotFound;

            productFeature.IsDelete = true;

            productFeatureRepository.Update(productFeature);
            productFeatureRepository.SaveAsync();

            return DeleteProductFeatureResult.Success;
        }

        public async Task<FilterProductFeatureViewModel> FilterAsync(FilterProductFeatureViewModel model)
        {
            return await productFeatureRepository.FilterAsync(model);
        }

        public async Task<UpdateProductFeatureViewModel> GetForEditAsync(int id)
        {
            var productFeature = await productFeatureRepository.GetByIdAsync(id);

            if (productFeature == null)
                return null;

            return new UpdateProductFeatureViewModel()
            {
                Id = productFeature.Id,
                ProductId = productFeature.ProductId,
                FeatureId = productFeature.FeatureId,
                FeatureValue = productFeature.FeatureValue,
                Order = productFeature.Order,
            };
        }

        public async Task<UpdateProductFeatureResult> UpdateAsync(UpdateProductFeatureViewModel model)
        {
            var productFeature = await productFeatureRepository.GetByIdAsync(model.Id);

            if (productFeature == null)
                return UpdateProductFeatureResult.ProductFeatureNotFound;

            if (!await productRepository.ExistAsync(model.ProductId))
                return UpdateProductFeatureResult.ProductNotFound;

            if (!await featureRepository.ExistAsync(model.FeatureId))
                return UpdateProductFeatureResult.FeatureNotFound;

            productFeature.ProductId = model.ProductId;
            productFeature.FeatureId = model.FeatureId;
            productFeature.Order = model.Order;
            productFeature.FeatureValue = model.FeatureValue;

            productFeatureRepository.Update(productFeature);
            await productFeatureRepository.SaveAsync();

            return UpdateProductFeatureResult.Success;
        }
    }
}
