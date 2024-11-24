using BigEshop.Domain.Models.Weblog;
using BigEshop.Domain.ViewModels.Weblog;
using BigEshop.Domain.ViewModels.WeblogCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Interfaces
{
    public interface IWeblogService
    {
        Task<CreateWeblogResult> CreateAsync(CreateWeblogViewModel model);

        Task<UpdateWeblogViewModel> GetForEditAsync(int id);

        Task<UpdateWeblogResult> UpdateAsync(UpdateWeblogViewModel model);

        Task<DeleteWeblogResult> DeleteAsync(int id);

        Task<List<Weblog>> GetAllAsync();

        Task<ClientWeblogDetailsViewModel> GetDetailsAsync(string slug);
    }
}
