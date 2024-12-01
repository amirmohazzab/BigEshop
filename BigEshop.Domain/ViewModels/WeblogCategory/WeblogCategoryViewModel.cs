using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.WeblogCategory
{
    public class WeblogCategoryViewModel
    {
        public int Id { get; set; }

        public string CategoryTitle { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreateDate { get; set; }

        public ICollection<Models.Weblog.Weblog> Weblogs { get; set; }
    }
}
