using BigEshop.Data.Context;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Feature;
using BigEshop.Domain.ViewModels.Feature;
using BigEshop.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BigEshop.Data.Implementations
{
    public class FeatureRepository (BigEshopContext context) : IFeatureRepository
    {
        
        public async Task<FilterFeatureViewModel> FilterAsync(FilterFeatureViewModel model)
        {
            var query = context.Features.Where(f => !f.IsDelete).AsQueryable();

            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(pf => pf.Title.Contains(model.Title));

            query = query.OrderByDescending(pf => pf.CreateDate);

            await model.Paging(query.Select(pf => new FeatureViewModel()
            {
                CreateDate = pf.CreateDate,
                Title = pf.Title,
                Id = pf.Id,
            }));

            return model;
        }

        public async Task<List<FeatureViewModel>> GetAllAsync()
        {
            return await context.Features.Where(f => !f.IsDelete)
                         .Select(f => new FeatureViewModel
                         {
                             Id = f.Id,
                             Title = f.Title,
                             CreateDate = f.CreateDate
                         }).ToListAsync();
        }

        public async Task<Feature> GetByIdAsync(int id)
        {
            return await context.Features.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task InserAsync(Feature feature)
        {
            await context.Features.AddAsync(feature);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(Feature feature)
        {
            context.Features.Update(feature);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await context.Features.AnyAsync(f => f.Id == id);
        }
    }
}
