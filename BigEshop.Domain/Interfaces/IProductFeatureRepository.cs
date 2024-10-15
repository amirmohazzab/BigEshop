using BigEshop.Domain.Models.Product;
using BigEshop.Domain.ViewModels.ProductFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Interfaces
{
    public interface IProductFeatureRepository
    {
        Task<FilterProductFeatureViewModel> FilterAsync(FilterProductFeatureViewModel model);

        Task InserAsync(ProductFeature productFeature);

        Task SaveAsync();

        void Update(ProductFeature productFeature);

        Task<ProductFeature?> GetByIdAsync(int id);
    }
}
