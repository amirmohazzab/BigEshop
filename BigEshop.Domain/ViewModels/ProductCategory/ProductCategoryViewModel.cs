﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreateDate { get; set; }
    }
}