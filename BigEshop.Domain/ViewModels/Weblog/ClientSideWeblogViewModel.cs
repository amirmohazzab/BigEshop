using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Weblog
{
    public class ClientSideWeblogViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Slug { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreateDate { get; set; }

        public ICollection<Models.Weblog.WeblogComment>? WeblogComments { get; set; }

        public ICollection<Models.Weblog.WeblogVisit>? WeblogVisits { get; set; }

    }
}
