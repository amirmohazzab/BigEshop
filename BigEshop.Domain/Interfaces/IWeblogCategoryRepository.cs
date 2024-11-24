using BigEshop.Domain.Models.Weblog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Interfaces
{
    public interface IWeblogCategoryRepository
    {
        
        Task InsertAsync(WeblogCategory weblogCategory);

        Task SaveAsync();

        void Update(WeblogCategory weblogCategory);

        Task<WeblogCategory?> GetByIdAsync(int id);

        Task<List<WeblogCategory>> GetAllAsync();
    }
}
