using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Product
{
    public class ProductFeature : BaseEntity<int>
    {
        public int ProductId { get; set; }

        public int FeatureId { get; set; }

        public string FeatureValue { get; set; }

        public int Order { get; set; }

        public bool IsDelete { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [ForeignKey("FeatureId")]
        public Feature.Feature? Feature { get; set; }

    }
}
