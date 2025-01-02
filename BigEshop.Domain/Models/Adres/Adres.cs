using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Adres
{
    public class Adres : BaseEntity<int>
    {
        public int UserId { get; set; }

        public string State { get; set; }

        public String City { get; set; }

        public string DetailAdres { get; set; }

        public string? PlaceName { get; set; }

        public bool IsDelete { get; set; }

        public string? Description { get; set; }

        public string? Phone { get; set; }

        public User.User? User { get; set; }

        public ICollection<Order.Order> Orders { get; set; }

    }
}
