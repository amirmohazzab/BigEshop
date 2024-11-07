using BigEshop.Data.Context;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.ViewModels.Product;
using BigEshop.Domain.ViewModels.ProductFeature;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Data.Implementations
{
    public class ProductFeatureRepository(BigEshopContext context) : IProductFeatureRepository
    {
        public async Task<FilterProductFeatureViewModel> FilterAsync(FilterProductFeatureViewModel model)
        {
            var query = context.ProductFeatures
                .Include(pf => pf.Product).Include(pf => pf.Feature).AsQueryable();

            if (!string.IsNullOrEmpty(model.FeatureValue))
                query = query.Where(pf => pf.FeatureValue.Contains(model.FeatureValue));

            if (!string.IsNullOrEmpty(model.Feature))
                query = query.Where(pf => pf.Feature != null && pf.Feature.Title.Contains(model.Feature));

            if (model.ProductId.HasValue)
                query = query.Where(pf => pf.ProductId == model.ProductId.Value);

            query = query.OrderByDescending(pf => pf.CreateDate);

            await model.Paging(query.Select(pf => new ProductFeatureViewModel()
            {
               CreateDate = pf.CreateDate,
               Id = pf.Id,
               FeatureValue = pf.FeatureValue,
               Order = pf.Order,
               IsDelete = pf.IsDelete,
               FeatureTitle = pf.Feature.Title,
               ProductTitle = pf.Product.Title
            }));

            return model;
        }

        public async Task<ProductFeature?> GetByIdAsync(int id)
        {
            return await context.ProductFeatures.Include(p => p.Product).FirstOrDefaultAsync(pf => pf.Id == id);
        }

        public async Task InserAsync(ProductFeature productFeature)
        {
            await context.ProductFeatures.AddAsync(productFeature);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(ProductFeature productFeature)
        {
            context.ProductFeatures.Update(productFeature);
        }
    }
}
