using BigEshop.Domain.Models.Feature;
using BigEshop.Domain.ViewModels.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Interfaces
{
    public interface IFeatureRepository
    {
        Task<FilterFeatureViewModel> FilterAsync(FilterFeatureViewModel model);

        Task InserAsync(Feature feature);

        Task SaveAsync();

        void Update(Feature feature);

        Task<Feature> GetByIdAsync(int id);

        Task<bool> ExistAsync(int id);

        Task<List<FeatureViewModel>> GetAllAsync();
    }
}
