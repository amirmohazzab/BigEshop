using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.ProductFeature
{
    public class ProductFeatureViewModel
    {
        public int Id { get; set; }

        public string ProductTitle { get; set; }

        public string FeatureTitle { get; set; }

        public string FeatureValue { get; set; }

        public int Order { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
