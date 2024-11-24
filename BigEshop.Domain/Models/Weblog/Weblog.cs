using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Weblog
{
    public class Weblog : BaseEntity<int>
    {
        public string Title { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Slug { get; set; }

        public bool IsDelete { get; set; }

        [ForeignKey("CategoryId")]
        public WeblogCategory? WeblogCategory { get; set; }

        public ICollection<WeblogComment>? WeblogComments { get; set; }
    }
}
