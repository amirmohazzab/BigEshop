using BigEshop.Domain.Models.Common;
using BigEshop.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.ProductCategory
{
    public class FilterProductCategoryViewModel : BasePaging<ProductCategoryViewModel>
    {
        public string? Title { get; set; }
    }
}
