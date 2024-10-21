using BigEshop.Domain.Models.Product;
using BigEshop.Domain.ViewModels.ProductColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Interfaces
{
    public interface IProductColorRepository
    {
        Task<bool> ExistProductColorAsync(int productId, string color);

        Task<FilterProductColorViewModel> FilterAsync(FilterProductColorViewModel model);

        Task InsertAsync(ProductColor productColor);

        Task SaveAsync();

        void Update(ProductColor productColor);

        Task<ProductColor?> GetByIdAsync(int id);
    }
}
