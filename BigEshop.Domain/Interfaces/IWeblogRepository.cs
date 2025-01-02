using BigEshop.Domain.Models.Product;
using BigEshop.Domain.Models.Weblog;
using BigEshop.Domain.ViewModels.Product;
using BigEshop.Domain.ViewModels.Weblog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Interfaces
{
    public interface IWeblogRepository
    {
        Task InsertAsync(Weblog weblog);

        Task SaveAsync();

        void Update(Weblog weblog);

        Task<Weblog> GetByIdAsync(int id);

        Task<List<Weblog>> GetAllAsync();

        Task<bool> ExistAsync(int id);

        Task<bool> ExistSlugAsync(string slug);

        Task<bool> DuplicatedSlugAsync(string slug, int id);

        Task<Weblog> GetBySlugAsync(string slug);

        Task<AdminSideFilterWeblogViewModel> FilterAsync(AdminSideFilterWeblogViewModel model);

        Task<ClientSideFilterWeblogViewModel> FilterAsync(ClientSideFilterWeblogViewModel model);
    }
}
