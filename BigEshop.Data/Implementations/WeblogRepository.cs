using BigEshop.Data.Context;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.Models.Weblog;
using BigEshop.Domain.ViewModels.Product;
using BigEshop.Domain.ViewModels.Weblog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Data.Implementations
{
    public class WeblogRepository (BigEshopContext context) : IWeblogRepository
    {
        public async Task<Weblog> GetByIdAsync(int id)
        => await context.Weblogs.FirstOrDefaultAsync(w => w.Id == id);

        public async Task InsertAsync(Weblog weblog)
        => await context.Weblogs.AddAsync(weblog);

        public async Task SaveAsync()
        => await context.SaveChangesAsync();

        public void Update(Weblog weblog)
        => context.Weblogs.Update(weblog);

        public async Task<List<Weblog>> GetAllAsync()
        => await context.Weblogs.Include(w => w.WeblogComments)
            .Include(w => w.WeblogCategory)
            .Include(w => w.WeblogVisits)
            .Where(w => w.IsDelete == false).ToListAsync();

        public async Task<bool> ExistAsync(int id)
        => await context.Weblogs.AnyAsync(w => w.Id == id);

        public async Task<bool> ExistSlugAsync(string slug)
        => await context.Weblogs.AnyAsync(w => w.Slug == slug);

        public async Task<bool> DuplicatedSlugAsync(string slug, int id)
        => await context.Weblogs.AnyAsync(w => w.Slug == slug && w.Id != id);

        public async Task<Weblog> GetBySlugAsync(string slug)
        {
            return await context.Weblogs.Include(w => w.WeblogCategory)
                .Include(w => w.WeblogComments).FirstOrDefaultAsync(w => w.Slug == slug && !w.IsDelete);
        }

        public async Task<AdminSideFilterWeblogViewModel> FilterAsync(AdminSideFilterWeblogViewModel model)
        {
            var query = context.Weblogs.Include(w => w.WeblogComments)
                    .Include(w => w.WeblogCategory)
                    .Include(w => w.WeblogVisits)
                    .Where(w => w.IsDelete == false).AsQueryable();

            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(p => p.Title.Contains(model.Title) || p.Description.Contains(model.Title));

            if (model.CategoryId.HasValue)
                query = query.Where(p => p.CategoryId == model.CategoryId.Value);

            await model.Paging(query.Select(p => new ClientSideWeblogViewModel()
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Title = p.Title,
                Description = p.Description,
                Image = p.Image,
                IsDelete = p.IsDelete,
                CreateDate = p.CreateDate,
                Slug = p.Slug,
                WeblogComments = p.WeblogComments,
                WeblogVisits = p.WeblogVisits,
                WeblogCategory = p.WeblogCategory
            }));

            return model;
        }

        public async Task<ClientSideFilterWeblogViewModel> FilterAsync(ClientSideFilterWeblogViewModel model)
        {
           
            var query = context.Weblogs.Include(w => w.WeblogComments)
                    .Include(w => w.WeblogCategory)
                    .Include(w => w.WeblogVisits)
                    .Where(w => w.IsDelete == false).AsQueryable();

            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(p => p.Title.Contains(model.Title) || p.Description.Contains(model.Title));

            if (model.CategoryId.HasValue)
                query = query.Where(p => p.CategoryId == model.CategoryId.Value);

            switch (model.WeblogOrderBy)
            {
                case ClientSideFilterWeblogOrderBy.MostVisited:
                    query = query.OrderByDescending(p => p.WeblogVisits.FirstOrDefault().Visit);
                    break;

                case ClientSideFilterWeblogOrderBy.CreateDateDesc:
                    query = query.OrderByDescending(p => p.CreateDate);
                    break;

                case ClientSideFilterWeblogOrderBy.CreateDateAsc:
                    query = query.OrderBy(p => p.CreateDate);
                    break;

                case ClientSideFilterWeblogOrderBy.MostUseful:
                    query = query.OrderByDescending(p => p.WeblogComments.Count());
                    break;
            }

            await model.Paging(query.Select(p => new ClientSideWeblogViewModel()
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Title = p.Title,
                Description = p.Description,
                Image = p.Image,
                IsDelete = p.IsDelete,
                CreateDate = p.CreateDate,
                Slug = p.Slug,
                WeblogComments = p.WeblogComments,
                WeblogVisits = p.WeblogVisits,
                WeblogCategory = p.WeblogCategory
            }));

            return model;
        }
    }
}
