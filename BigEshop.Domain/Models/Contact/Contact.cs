using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Contact
{
    public class Contact : BaseEntity<int>
    {
        public string FullName { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }
    }
}
