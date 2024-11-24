using BigEshop.Data.Context;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.Models.Weblog;
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
        => await context.Weblogs.Include(w => w.WeblogComments).Where(w => w.IsDelete == false).ToListAsync();

        public async Task<bool> ExistAsync(int id)
        => await context.Weblogs.AnyAsync(w => w.Id == id);

        public async Task<bool> ExistSlugAsync(string slug)
        => await context.Weblogs.AnyAsync(w => w.Slug == slug);

        public async Task<bool> DuplicatedSlugAsync(string slug, int id)
        => await context.Weblogs.AnyAsync(w => w.Slug == slug && w.Id == id);

        public async Task<Weblog> GetBySlugAsync(string slug)
        {
            return await context.Weblogs.Include(w => w.WeblogCategory)
                .Include(w => w.WeblogComments).FirstOrDefaultAsync(w => w.Slug == slug && !w.IsDelete);
        }
    }
}
