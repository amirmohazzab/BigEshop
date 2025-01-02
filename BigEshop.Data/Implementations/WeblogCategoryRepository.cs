using BigEshop.Data.Context;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Weblog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Data.Implementations
{
    public class WeblogCategoryRepository (BigEshopContext context) : IWeblogCategoryRepository
    {
       
        public async Task<WeblogCategory?> GetByIdAsync(int id)
            => await context.WeblogCategories.FirstOrDefaultAsync(wc => wc.Id == id);

        public async Task InsertAsync(WeblogCategory weblogCategory)
            => await context.WeblogCategories.AddAsync(weblogCategory);

        public async Task SaveAsync()
            => await context.SaveChangesAsync();

        public void Update(WeblogCategory weblogCategory)
            => context.WeblogCategories.Update(weblogCategory);

        public async Task<List<WeblogCategory>> GetAllAsync()
            => await context.WeblogCategories.Where(wc => !wc.IsDelete).ToListAsync();
    }
}
