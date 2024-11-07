using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Weblog
{
    public class Weblog : BaseEntity<int>
    {
        public string Title { get; set; }

        public string CategoryId { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Slug { get; set; }

        public bool IsDelete { get; set; }

        public WeblogCategory WeblogCategory { get; set; }
    }
}
