using BigEshop.Application.Extensions;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Application.Statics;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.Models.ProductCategory;
using BigEshop.Domain.ViewModels.Product;
using BigEshop.Domain.ViewModels.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
    public class ProductService 
        (IProductRepository productRepository) 
        : IProductService
    {
        
        public async Task<AdminSideFilterProductViewModel> FilterAsync(AdminSideFilterProductViewModel model)
        {
            return await productRepository.FilterAsync(model);
        }

        public async Task<CreateProductResult> CreateAsync(CreateProductViewModel model)
        {
            Product product = new Product()
            {
                CategoryId = model.CategoryId,
                Title = model.Title,
                Price = model.Price,
                Description = model.Description,
                IsDelete = false,
                CreateDate = DateTime.Now
            };

            if (model.Image != null)
            {
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);

                string path = PathTools.ProductImagePath;
                model.Image.AddImageToServer(imageName, path);

                product.Image = imageName;
            }

            await productRepository.InsertAsync(product);
            await productRepository.SaveAsync();

            return CreateProductResult.Success;
        }

        public async Task<UpdateProductViewModel> GetProductForEditAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product == null)
                return null;

            return new UpdateProductViewModel()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Title = product.Title,
                Price = product.Price,
                Description = product.Description,
                ImageName = product.Image,
            };
        }

        public async Task<UpdateProductResult> UpdateAsync(UpdateProductViewModel model)
        {
            var product = await productRepository.GetByIdAsync(model.Id);

            if (product == null)
                return UpdateProductResult.ProductNotFound;

            product.CategoryId = model.CategoryId;
            product.Title = model.Title;
            product.Price = model.Price;
            product.Description = model.Description;
                
            if (model.NewImage != null)
            {
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.NewImage.FileName);

                string path = PathTools.ProductImagePath;
                model.NewImage.AddImageToServer(imageName, path, null, null, null, product.Image);

                product.Image = imageName;
            }

            productRepository.Update(product);
            await productRepository.SaveAsync();

            return UpdateProductResult.Success;


        }

        public async Task<DeleteProductResult> DeleteAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product == null)
                return DeleteProductResult.ProductNotFound;

            product.IsDelete = true;

            productRepository.Update(product);
            await productRepository.SaveAsync();

            return DeleteProductResult.Success;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await productRepository.GetByIdAsync(id);
        }

        public async Task<ClientSideFilterProductViewModel> FilterAsync(ClientSideFilterProductViewModel model)
        {
            return await productRepository.FilterAsync(model);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await productRepository.ExistAsync(id);
        }
    }
}
