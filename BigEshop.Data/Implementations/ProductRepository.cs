using BigEshop.Data.Context;
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
            var query = context.Products
                .Include(pc => pc.ProductCategory)
                .Include(pg => pg.ProductGalleries)
                .AsQueryable();

            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(p => p.Title.Contains(model.Title) || p.Description.Contains(model.Title));

            if (model.Price.HasValue)
                query = query.Where(p => p.Price == model.Price.Value);

            if (model.CategoryId.HasValue)
                query = query.Where(p => p.CategoryId == model.CategoryId.Value);

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
                CreateDate = p.CreateDate,
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
            => await context.Products.Include(pg => pg.ProductGalleries).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<ClientSideFilterProductViewModel> FilterAsync(ClientSideFilterProductViewModel model)
        {
            var query = context.Products.Where(p => !p.IsDelete).AsQueryable();

            #region Filter

            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(p => p.Title.Contains(model.Title) || p.Description.Contains(model.Title));

            if (model.Price.HasValue)
            {
                query = query.Where(p => p.Price == model.Price.Value);
                query = query.OrderByDescending(p => p.Price);
            }
               
            if (model.CategoryId.HasValue)
                query = query.Where(p => p.CategoryId == model.CategoryId.Value);

            if (model.Min.HasValue && model.Max.HasValue)
            {
                query = query.Where(p => p.Price < model.Max.Value && p.Price > model.Min.Value);
                query = query.OrderByDescending(p => p.Price);
            }

            if (model.Min.HasValue)
            {
                query = query.Where(p => p.Price > model.Min.Value);
                query = query.OrderBy(p => p.Price);
            }
                
            if (model.Max.HasValue)
            {
                query = query.Where(p => p.Price < model.Max.Value);
                query = query.OrderByDescending(p => p.Price);
            }
                
            #endregion

            #region OrderBy

            switch (model.OrderBy)
            {
                case ClientSideFilterProductOrderBy.MostVisited:
                    query = query.OrderByDescending(p => p.ProductVisits.FirstOrDefault().Visit);
                    break;

                case ClientSideFilterProductOrderBy.CreateDateDesc:
                    query = query.OrderByDescending(p => p.CreateDate);
                    break;

                case ClientSideFilterProductOrderBy.CreateDateAsc:
                    query = query.OrderBy(p => p.CreateDate);
                    break;

                case ClientSideFilterProductOrderBy.BestSeller:
                    query = query.OrderByDescending(p => p.OrderDetails.FirstOrDefault().Product.Quantity);
                    break;

                case ClientSideFilterProductOrderBy.MostPopular:
                    query = query.Where(p => p.ProductReactions.FirstOrDefault().Reaction == true);
                    break;

                case ClientSideFilterProductOrderBy.MostExpensive:
                    query = query.OrderByDescending(p => p.Price);
                    break;

                case ClientSideFilterProductOrderBy.Cheapest:
                    query = query.OrderBy(p => p.Price);
                    break;

            }

            #endregion

            await model.Paging(query.Select(p => new ClientSideProductViewModel()
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Title = p.Title,
                Price = p.Price,
                Description = p.Description,
                Image = p.Image,
                IsDelete = p.IsDelete,
                CreateDate = p.CreateDate,
                Slug = p.Slug,
                ProductColors = p.ProductColors.Where(pc => pc.IsDelete == false).ToList(),
                productVisits = p.ProductVisits.ToList(),
                productReactions = p.ProductReactions.ToList()
            }));

            return model;
        }

        public async Task<bool> ExistAsync(int id)
        => await context.Products.AnyAsync(p => p.Id == id);

        public async Task<bool> ExistSlugAsync(string slug)
        => await context.Products.AnyAsync(p => p.Slug == slug);

        public async Task<bool> DuplicatedSlugAsync(string slug, int id)
        => await context.Products.AnyAsync(p => p.Slug == slug && p.Id != id);

        public async Task<Product> GetBySlugAsync(string slug)
        {
            return await context.Products
                .Include(P => P.ProductGalleries)
                .Include(p => p.ProductFeatures)
                .ThenInclude(p => p.Feature)
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductColors)
                .Include(p => p.ProductComments)
                .Include(p => p.ProductCommentReactions)
                .Include(p => p.ProductQuestions)
                .Include(p => p.ProductAnswers)
                .Include(p => p.ProductAnswerReactions)
                .Include(p => p.ProductVisits)
                .Include(p => p.ProductReactions)
                .FirstOrDefaultAsync(p => p.Slug == slug && !p.IsDelete);

        }

        public async Task<List<Product>> ShowByCategoryAsync(int categoryId)
            => await context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
    }
}
