using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Migrations;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.ViewModels.ProductColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
    public class ProductColorService 
        (IProductRepository productRepository,
        IProductColorRepository productColorRepository) 
        : IProductColorService
    {
        public async Task<CreateProductColorResult> CreateAsync(CreateProductColorViewModel model)
        {
            if (!await productRepository.ExistAsync(model.ProductId))
                return CreateProductColorResult.ProductNotFound;

            if (await productColorRepository.ExistProductColorAsync(model.ProductId, model.Color))
                return CreateProductColorResult.ExistProductColor;

            ProductColor productColor = new()
            {
                ProductId = model.ProductId,
                Color = model.Color,
                CreateDate = DateTime.Now,
                Price = model.Price,
                IsDelete = false,
                ColorTitle = model.ColorTitle,
                Quantity = model.Quantity
            };

            await productColorRepository.InsertAsync(productColor);
            await productColorRepository.SaveAsync();

            return CreateProductColorResult.Success;
        }

        public async Task<DeleteProductColorResult> DeleteAsync(int id)
        {
            var productColor = await productColorRepository.GetByIdAsync(id);

            if (productColor == null)
                return DeleteProductColorResult.ProductColorNotFound;

            productColor.IsDelete = true;

            productColorRepository.Update(productColor);
            await productColorRepository.SaveAsync();

            return DeleteProductColorResult.Success;
        }

        public async Task<FilterProductColorViewModel> FilterAsync(FilterProductColorViewModel model)
        {
            return await productColorRepository.FilterAsync(model);
        }

        public async Task<UpdateProductColorViewModel> GetForEditAsync(int id)
        {
            var productColor = await productColorRepository.GetByIdAsync(id);

            if (productColor == null)
                return null;

            return new UpdateProductColorViewModel()
            {
                Id = productColor.Id,
                ProductId = productColor.ProductId,
                Color = productColor.Color,
                Price = productColor.Price,
                ColorTitle = productColor.ColorTitle,
                Quantity = productColor.Quantity,
                ProductTitle = productColor.Product.Title
            };
        }

        public async Task<UpdateProductColorResult> UpdateAsync(UpdateProductColorViewModel model)
        {
            if (!await productRepository.ExistAsync(model.ProductId))
                return UpdateProductColorResult.ProductNotFound;

            var productColor = await productColorRepository.GetByIdAsync(model.Id);

            if (productColor == null)
                return UpdateProductColorResult.ProductColorNotFound;

            productColor.Color = model.Color;
            productColor.Price = model.Price;
            productColor.ColorTitle = model.ColorTitle;
            productColor.Quantity = model.Quantity;
          

            productColorRepository.Update(productColor);
            await productColorRepository.SaveAsync();

            return UpdateProductColorResult.Success;


        }
    }
}
