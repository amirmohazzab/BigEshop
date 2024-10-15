using BigEshop.Domain.Models.Product;
using BigEshop.Domain.Models.ProductCategory;
using BigEshop.Domain.ViewModels.Product;
using BigEshop.Domain.ViewModels.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<AdminSideFilterProductViewModel> FilterAsync(AdminSideFilterProductViewModel model);

        Task<CreateProductResult> CreateAsync(CreateProductViewModel model);

        Task<UpdateProductViewModel> GetProductForEditAsync(int id);

        Task<UpdateProductResult> UpdateAsync(UpdateProductViewModel model);

        Task<DeleteProductResult> DeleteAsync(int id);

        Task<Product> GetByIdAsync(int id);

        Task<ClientSideFilterProductViewModel> FilterAsync(ClientSideFilterProductViewModel model);

        Task<bool> ExistAsync(int id);
    }
}
