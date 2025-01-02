using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Implementations;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.ProductCategory;
using BigEshop.Domain.Models.Weblog;
using BigEshop.Domain.ViewModels.Product;
using BigEshop.Domain.ViewModels.ProductCategory;
using BigEshop.Domain.ViewModels.WeblogCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
    public class WeblogCategoryService 
        (IWeblogCategoryRepository weblogCategoryRepository) 
        : IWeblogCategoryService
    {
        public async Task<CreateWeblogCategoryResult> CreateAsync(CreateWeblogCategoryViewModel model)
        {
            WeblogCategory weblogCategory = new()
            {
                CreateDate = DateTime.Now,
                CategoryTitle = model.CategoryTitle,
                IsDelete = false
            };

            await weblogCategoryRepository.InsertAsync(weblogCategory);
            await weblogCategoryRepository.SaveAsync();

            return CreateWeblogCategoryResult.Success;
        }

        public async Task<DeleteWeblogCategoryResult> DeleteAsync(int id)
        {
            var weblogCategory = await weblogCategoryRepository.GetByIdAsync(id);

            if (weblogCategory == null)
                return DeleteWeblogCategoryResult.WeblogCategoryNotFound;

            weblogCategory.IsDelete = true;
            weblogCategoryRepository.Update(weblogCategory);
            await weblogCategoryRepository.SaveAsync();

            return DeleteWeblogCategoryResult.Success;
        }

        public async Task<WeblogCategory> GetByIdAsync(int id)
        {
            return await weblogCategoryRepository.GetByIdAsync(id);
        }

        public async Task<UpdateWeblogCategoryViewModel> GetForEditAsync(int id)
        {
            var weblogCategory = await weblogCategoryRepository.GetByIdAsync(id);

            if (weblogCategory == null)
                return null;

            return new UpdateWeblogCategoryViewModel()
            {
                Id = weblogCategory.Id,
                CategoryTitle = weblogCategory.CategoryTitle
            };
        }

        public async Task<UpdateWeblogCategoryResult> Update(UpdateWeblogCategoryViewModel model)
        {
            var weblogCategory = await weblogCategoryRepository.GetByIdAsync(model.Id);

            if (weblogCategory == null)
                return UpdateWeblogCategoryResult.WeblogCategoryNotFound;

            weblogCategory.CategoryTitle = model.CategoryTitle;

            weblogCategoryRepository.Update(weblogCategory);
            await weblogCategoryRepository.SaveAsync();

            return UpdateWeblogCategoryResult.Success;
        }

        public async Task<List<WeblogCategory>> GetAllAsync()
        {
            return await weblogCategoryRepository.GetAllAsync();
        }

    }
}
