using BigEshop.Domain.Models.ProductCategory;
using BigEshop.Domain.ViewModels.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task InsertAsync(ProductCategory productCategory);

        Task SaveAsync();

        void Update(ProductCategory productCategory);

        Task<ProductCategory?> GetByIdAsync(int id);

        Task<List<ProductCategoryViewModel>> GetAllParentsAsync();

        Task<FilterProductCategoryViewModel> FilterAsync(FilterProductCategoryViewModel model);

        Task<List<ProductCategoryViewModel>> GetAllChildCategoriesAsync();

    }
}
