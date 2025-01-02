using BigEshop.Application.Services.Interfaces;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Adres;
using BigEshop.Domain.Models.User;
using BigEshop.Domain.ViewModels.Adres;
using BigEshop.Domain.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigEshop.Domain.Models.Product;
using Microsoft.AspNetCore.Http;

namespace BigEshop.Application.Services.Implementations
{
    public class AdresService (IAdresRepository adresRepository) : IAdresService
    {
        public async Task<CreateAdresResult> CreateAsync(CreateAdresViewModel model)
        {

            Adres adres = new()
            {
                State = model.State,
                City = model.City,
                DetailAdres = model.DetailAdres,
                Description = model.Description,
                PlaceName = model.PlaseName,
                //UserId = User.GetUserId(),
                CreateDate = DateTime.Now,
                Phone = model.Phone
            };

            await adresRepository.InsertAsync(adres);
            await adresRepository.SaveAsync();

            return CreateAdresResult.Success;
        }

        public async Task<DeleteAdresResult> DeleteAsync(int id)
        {
            var adres = await adresRepository.GetByIdAsync(id);

            if (adres == null)
                return DeleteAdresResult.AdresNotFound;

            adres.IsDelete = true;
            adresRepository.Update(adres);
            await adresRepository.SaveAsync();

            return DeleteAdresResult.Success;
        }

        public async Task<UpdateAdresViewModel> GetAdresForEditAsync(int id)
        {
            var adres = await adresRepository.GetByIdAsync(id);

            if (adres == null)
                return null;

            return new UpdateAdresViewModel()
            {
                Id = adres.Id,
                DetailAdres = adres.DetailAdres,
                Description = adres.Description,
                City = adres.City,
                State = adres.State,
                PlaceName = adres.PlaceName,
                Phone = adres.Phone
            };
        }

        public async Task<List<Adres>> GetAllAsync()
        {
            return await adresRepository.GetAllAsync();
        }

        public async Task<UpdateAdresResult> UpdateAsync(UpdateAdresViewModel model)
        {
            var adres = await adresRepository.GetByIdAsync(model.Id);

            if (adres == null)
                return UpdateAdresResult.AdresNotFound;

            adres.State = model.State;
            adres.City = model.City;
            adres.DetailAdres = model.DetailAdres;
            adres.Description = model.Description;
            adres.PlaceName = model.PlaceName;
            adres.Phone = model.Phone;

            adresRepository.Update(adres);
            await adresRepository.SaveAsync();

            return UpdateAdresResult.Success;
        }
    }
}
