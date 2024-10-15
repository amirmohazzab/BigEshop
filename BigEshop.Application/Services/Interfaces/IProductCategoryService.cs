using BigEshop.Domain.Models.ProductCategory;
using BigEshop.Domain.ViewModels.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Interfaces
{
    public interface IProductCategoryService
    {
        Task<CreateProductCategoryResult> CreateAsync(CreateProductCategoryViewModel model);

        Task<List<ProductCategoryViewModel>> GetAllParentsAsync();

        Task<UpdateProductCategoryViewModel> GetForEditAsync(int id);

        Task<UpdateProductCategoryResult> UpdateAsync(UpdateProductCategoryViewModel model);

        Task<DeleteProductCategoryResult> DeleteAsync(int id);

        Task<FilterProductCategoryViewModel> FilterAsync(FilterProductCategoryViewModel model);

        Task<ProductCategory> GetByIdAsync(int id);

        Task<List<ProductCategoryViewModel>> GetAllChildCategoriesAsync();
    }
}
