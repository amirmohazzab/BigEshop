using BigEshop.Data.Context;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.ViewModels.ProductGallery;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Data.Implementations
{
    public class ProductGalleryRepository 
        (BigEshopContext context) 
        : IProductGalleryRepository
    {
        public async Task<FilterProductGalleryViewModel> FilterAsync(FilterProductGalleryViewModel model)
        {
            var query = context.ProductGalleries.AsQueryable();

            if (!string.IsNullOrEmpty(model.ImageTitle))
                query = query.Where(pg => pg.ImageTitle.Contains(model.ImageTitle));

            if (model.ProductId.HasValue)
                query = query.Where(pg => pg.ProductId == model.ProductId.Value);

            query = query.OrderByDescending(pg => pg.CreateDate);

            await model.Paging(query.Select(pg => new ProductGalleryViewModel()
            {
                CreateDate = pg.CreateDate,
                Id = pg.Id,
                ProductId = pg.ProductId,
                ImageName = pg.ImageName,
                ImageTitle = pg.ImageTitle
            }));

            return model;
        }

        public async Task<ProductGallery> GetByIdAsync(int id)
        => await context.ProductGalleries.FirstOrDefaultAsync(pg => pg.Id == id);

        public async Task InserAsync(ProductGallery productGallery)
        => await context.ProductGalleries.AddAsync(productGallery);

        public void Remove(ProductGallery productGallery)
        => context.ProductGalleries.Remove(productGallery);

        public async Task SaveAsync()
        => await context.SaveChangesAsync();
        
    }
}
