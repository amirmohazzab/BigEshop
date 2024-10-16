﻿using BigEshop.Data.Context;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.Models.ProductCategory;
using BigEshop.Domain.ViewModels.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Data.Implementations
{
    public class ProductRepository (BigEshopContext context) : IProductRepository
    {
        public async Task<AdminSideFilterProductViewModel> FilterAsync(AdminSideFilterProductViewModel model)
        {
            var query = context.Products.Include(pg => pg.ProductCategory).AsQueryable();

            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(p => p.Title.Contains(model.Title));

            if (model.Price.HasValue)
                query = query.Where(p => p.Price == model.Price.Value);

            switch (model.Status)
            {
                case FilterProductStatus.NotDeleted:
                    query = query.Where(p => !p.IsDelete);
                    break;

                case FilterProductStatus.All:
                    break;

                case FilterProductStatus.Deleted:
                    query = query.Where(p => p.IsDelete);
                    break;
            };

            query = query.OrderByDescending(p => p.CreateDate);

            await model.Paging(query.Select(p => new ProductViewModel()
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Title = p.Title,
                Price = p.Price,
                Description = p.Description,
                Image = p.Image,
                IsDelete = p.IsDelete,
                CreateDate = p.CreateDate
            }));

            return model;
        }

        public async Task InsertAsync(Product product)
            => await context.Products.AddAsync(product);

        public async Task SaveAsync()
            => await context.SaveChangesAsync();

        public void Update(Product product)
            => context.Products.Update(product);

        public async Task<Product> GetByIdAsync(int id)
            => await context.Products.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<ClientSideFilterProductViewModel> FilterAsync(ClientSideFilterProductViewModel model)
        {
            var query = context.Products.Where(p => !p.IsDelete).AsQueryable();

            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(p => p.Title.Contains(model.Title));

            if (model.Price.HasValue)
                query = query.Where(p => p.Price == model.Price.Value);

            
            query = query.OrderByDescending(p => p.CreateDate);

            await model.Paging(query.Select(p => new ClientSideProductViewModel()
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Title = p.Title,
                Price = p.Price,
                Description = p.Description,
                Image = p.Image,
                IsDelete = p.IsDelete,
                CreateDate = p.CreateDate
            }));

            return model;
        }

        public async Task<bool> ExistAsync(int id)
        => await context.Products.AnyAsync(p => p.Id == id);
    }
}
