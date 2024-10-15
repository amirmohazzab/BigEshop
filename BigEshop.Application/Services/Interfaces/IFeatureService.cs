using BigEshop.Domain.ViewModels.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Interfaces
{
    public interface IFeatureService
    {
        Task<CreateFeatureResult> CreateAsync(CreateFeatureViewModel model);

        Task<UpdateFeatureViewModel> GetForEditAsync(int id);

        Task<UpdateFeatureResult> UpdateAsync(UpdateFeatureViewModel model);

        Task<DeleteFeatureResult> DeleteAsync(int id);

        Task<FilterFeatureViewModel> FilterAsync(FilterFeatureViewModel model);

        Task<List<FeatureViewModel>> GetAllAsync();
    }
}
