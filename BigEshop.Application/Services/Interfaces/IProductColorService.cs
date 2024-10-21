using BigEshop.Domain.ViewModels.ProductColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Interfaces
{
    public interface IProductColorService
    {
        Task<CreateProductColorResult> CreateAsync(CreateProductColorViewModel model);

        Task<UpdateProductColorViewModel> GetForEditAsync(int id);

        Task<UpdateProductColorResult> UpdateAsync(UpdateProductColorViewModel model);

        Task<DeleteProductColorResult> DeleteAsync(int id);

        Task<FilterProductColorViewModel> FilterAsync(FilterProductColorViewModel model);
    }
}
