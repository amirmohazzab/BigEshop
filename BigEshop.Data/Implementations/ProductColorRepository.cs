using BigEshop.Data.Context;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.ViewModels.ProductColor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Data.Implementations
{
    public class ProductColorRepository (BigEshopContext context) : IProductColorRepository
    {
        public async Task<bool> ExistProductColorAsync(int productId, string color)
        {
            return await context.ProductColors.AnyAsync(pc => pc.Color.Contains(color) && pc.ProductId == productId);
        }

        public async Task<FilterProductColorViewModel> FilterAsync(FilterProductColorViewModel model)
        {
            var query = context.ProductColors.Where(p => p.ProductId == model.ProductId).AsQueryable();

            if (!string.IsNullOrEmpty(model.ColorTitle))
                query = query.Where(pc => pc.ColorTitle.Contains(model.ColorTitle));

            if (model.Price.HasValue)
                query = query.Where(pc => pc.Price == model.Price);

            query = query.OrderByDescending(pc => pc.CreateDate);

            await model.Paging(query.Select(pc => new ProductColorViewModel
            {
                CreateDate = pc.CreateDate,
                Id = pc.Id,
                IsDelete = pc.IsDelete,
                Quantity = pc.Quantity,
                ProductId = pc.ProductId,
                Color = pc.Color,
                ColorTitle = pc.ColorTitle,
                Price = pc.Price
            }));

            return model;
        }

        public async Task<ProductColor?> GetByIdAsync(int id)
        {
            return await context.ProductColors.FirstOrDefaultAsync(pc => pc.Id == id);
        }

        public async Task InsertAsync(ProductColor productColor)
        {
            await context.ProductColors.AddAsync(productColor);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(ProductColor productColor)
        {
            context.ProductColors.Update(productColor);
        }
    }
}
