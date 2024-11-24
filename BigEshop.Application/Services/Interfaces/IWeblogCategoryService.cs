using BigEshop.Domain.Models.Weblog;
using BigEshop.Domain.ViewModels.WeblogCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Interfaces
{
    public interface IWeblogCategoryService
    {
        Task<CreateWeblogCategoryResult> CreateAsync(CreateWeblogCategoryViewModel model);

        Task<UpdateWeblogCategoryViewModel> GetForEditAsync(int id);

        Task<UpdateWeblogCategoryResult> UpdateAsync(UpdateWeblogCategoryViewModel model);

        Task<DeleteWeblogCategoryResult> DeleteAsync(int id);

        Task<WeblogCategory> GetByIdAsync(int id);

        Task<List<WeblogCategory>> GetAllAsync();
    }
}
