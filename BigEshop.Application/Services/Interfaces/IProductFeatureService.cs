using BigEshop.Domain.ViewModels.ProductFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Interfaces
{
    public interface IProductFeatureService
    {
        Task<CreateProductFeatureResult> CreateAsync(CreateProductFeatureViewModel model);

        Task<UpdateProductFeatureViewModel> GetForEditAsync(int id);

        Task<UpdateProductFeatureResult> UpdateAsync(UpdateProductFeatureViewModel model);

        Task<DeleteProductFeatureResult> DeleteAsync(int id);

        Task<FilterProductFeatureViewModel> FilterAsync(FilterProductFeatureViewModel model);
    }
}
