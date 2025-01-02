using BigEshop.Domain.Models.Adres;
using BigEshop.Domain.ViewModels.Adres;
using BigEshop.Domain.ViewModels.ContactUs;
using BigEshop.Domain.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Interfaces
{
    public interface IAdresService
    {
        Task<List<Adres>> GetAllAsync();

        Task<CreateAdresResult> CreateAsync(CreateAdresViewModel model);

        Task<UpdateAdresViewModel> GetAdresForEditAsync(int id);

        Task<UpdateAdresResult> UpdateAsync(UpdateAdresViewModel model);

        Task<DeleteAdresResult> DeleteAsync(int id);
    }
}
