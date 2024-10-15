using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Implementations;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Feature;
using BigEshop.Domain.ViewModels.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
    public class FeatureService (IFeatureRepository featureRepository) : IFeatureService
    {
        public async Task<CreateFeatureResult> CreateAsync(CreateFeatureViewModel model)
        {
            Feature feature = new()
            {
                Title = model.Title,
                IsDelete = false,
                CreateDate = DateTime.Now
            };

            await featureRepository.InserAsync(feature);
            await featureRepository.SaveAsync();

            return CreateFeatureResult.Success;
        }

        public async Task<DeleteFeatureResult> DeleteAsync(int id)
        {
            var feature = await featureRepository.GetByIdAsync(id);

            if (feature == null)
                return DeleteFeatureResult.FeatureNotFound;

            feature.IsDelete = true;

            featureRepository.Update(feature);
            await featureRepository.SaveAsync();

            return DeleteFeatureResult.Success;
        }

        public async Task<FilterFeatureViewModel> FilterAsync(FilterFeatureViewModel model)
        {
            return await featureRepository.FilterAsync(model);
        }

        public async Task<List<FeatureViewModel>> GetAllAsync()
        {
            return await featureRepository.GetAllAsync();
        }

        public async Task<UpdateFeatureViewModel> GetForEditAsync(int id)
        {
            var feature = await featureRepository.GetByIdAsync(id);

            if (feature == null)
                return null;

            return new UpdateFeatureViewModel()
            {
                Title = feature.Title,
                Id = feature.Id
            };
        }

        public async Task<UpdateFeatureResult> UpdateAsync(UpdateFeatureViewModel model)
        {
            var feature = await featureRepository.GetByIdAsync(model.Id);

            if (feature == null)
                return UpdateFeatureResult.FeatureNotFound;

            feature.Title = model.Title;

            featureRepository.Update(feature);
            await featureRepository.SaveAsync();

            return UpdateFeatureResult.Success;
        }
    }
}
