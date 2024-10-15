using BigEshop.Data.Context;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.ProductCategory;
using BigEshop.Domain.ViewModels.ProductCategory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Data.Implementations
{
    public class ProductCategoryRepository (BigEshopContext context) : IProductCategoryRepository
    {
        public async Task<ProductCategory?> GetByIdAsync(int id)
            => await context.ProductCategories.FirstOrDefaultAsync(pc => pc.Id == id);

        public async Task InsertAsync(ProductCategory productCategory)
            => await context.ProductCategories.AddAsync(productCategory);

        public async Task SaveAsync()
            => await context.SaveChangesAsync();

        public void Update(ProductCategory productCategory)
            => context.ProductCategories.Update(productCategory);

        public async Task<List<ProductCategoryViewModel>> GetAllParentsAsync()
            => await context.ProductCategories.Where(pc => pc.ParentId == null)
            .Select(pc => new ProductCategoryViewModel()
            {
                Id = pc.Id,
                Title = pc.Title,
                ParentId = pc.ParentId,
                CreateDate = pc.CreateDate
            })
            .ToListAsync();

        public async Task<FilterProductCategoryViewModel> FilterAsync(FilterProductCategoryViewModel model)
        {
            var query = context.ProductCategories.AsQueryable();

            if (!string.IsNullOrEmpty(model.Title))
            {
                query = query.Where(pc => pc.Title.Contains(model.Title));
            }

            query = query.OrderByDescending(pc => pc.CreateDate);

            await model.Paging(query.Select(pc => new ProductCategoryViewModel()
            {
                ParentId = pc.Id,
                Id = pc.Id,
                CreateDate = pc.CreateDate,
                Title = pc.Title
            }));

            return model;
        }

        public async Task<List<ProductCategoryViewModel>> GetAllChildCategoriesAsync()
        {
            return await context.ProductCategories.Where(pc => pc.ParentId.HasValue && !pc.IsDelete)
            .Select(pc => new ProductCategoryViewModel()
            {
                ParentId = pc.Id,
                Id = pc.Id,
                Title = pc.Title,
                CreateDate = pc.CreateDate
            }).ToListAsync();
        }
            
    }
}
