using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.ProductCategory;
using BigEshop.Domain.ViewModels.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
    public class ProductCategoryService 
        (IProductCategoryRepository productCategoryRepository) 
        : IProductCategoryService
    {
        public async Task<CreateProductCategoryResult> CreateAsync(CreateProductCategoryViewModel model)
        {
            ProductCategory productCategory = new()
            {
                CreateDate = DateTime.Now,
                ParentId = model.ParentId,
                Title = model.Title
            };

            await productCategoryRepository.InsertAsync(productCategory);
            await productCategoryRepository.SaveAsync();

            return CreateProductCategoryResult.Success;
        }

        public async Task<List<ProductCategoryViewModel>> GetAllParentsAsync()
        {
            return await productCategoryRepository.GetAllParentsAsync();
        }

        public async Task<UpdateProductCategoryViewModel> GetForEditAsync(int id)
        {
            var productCategory = await productCategoryRepository.GetByIdAsync(id);

            if (productCategory == null)
                return null;

            return new UpdateProductCategoryViewModel()
            {
                Id = productCategory.Id,
                Title = productCategory.Title,
                ParentId = productCategory.ParentId
            };
        }

        public async Task<UpdateProductCategoryResult> UpdateAsync(UpdateProductCategoryViewModel model)
        {
            var productCategory = await productCategoryRepository.GetByIdAsync(model.Id);

            if (productCategory == null)
                return UpdateProductCategoryResult.ProductCategoryNotFound;

            productCategory.Title = model.Title;
            productCategory.ParentId = model.ParentId;

            productCategoryRepository.Update(productCategory);
            await productCategoryRepository.SaveAsync();

            return UpdateProductCategoryResult.Success;
        }

        public async Task<DeleteProductCategoryResult> DeleteAsync(int id)
        {
            var productCategory = await productCategoryRepository.GetByIdAsync(id);

            if (productCategory == null)
                return DeleteProductCategoryResult.ProductCategoryNotFound;

            productCategory.IsDelete = true;
            productCategoryRepository.Update(productCategory);
            await productCategoryRepository.SaveAsync();

            return DeleteProductCategoryResult.Success;
        }

        public async Task<FilterProductCategoryViewModel> FilterAsync(FilterProductCategoryViewModel model)
        {
            return await productCategoryRepository.FilterAsync(model);
        }

        public async Task<ProductCategory> GetByIdAsync(int id)
        {
            return await productCategoryRepository.GetByIdAsync(id);
        }
    }
}
