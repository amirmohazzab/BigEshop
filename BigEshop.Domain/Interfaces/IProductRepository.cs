using BigEshop.Domain.Models.Product;
using BigEshop.Domain.Models.ProductCategory;
using BigEshop.Domain.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<AdminSideFilterProductViewModel> FilterAsync(AdminSideFilterProductViewModel model);

        Task InsertAsync(Product product);

        Task SaveAsync();

        void Update(Product product);

        Task<Product> GetByIdAsync(int id);

        Task<ClientSideFilterProductViewModel> FilterAsync(ClientSideFilterProductViewModel model);

        Task<bool> ExistAsync(int id);

        Task<bool> ExistSlugAsync(string slug);

        Task<bool> DuplicatedSlugAsync(string slug, int id);

        Task<Product> GetBySlugAsync(string slug);
    }
}
