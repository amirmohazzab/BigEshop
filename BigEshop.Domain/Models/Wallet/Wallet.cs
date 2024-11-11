using BigEshop.Domain.Enums.Wallet;
using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Wallet
{
    public class Wallet : BaseEntity<int>
    {
        public int UserId { get; set; }

        public int? OrderId { get; set; }

        public int Price { get; set; }

        public TransactionType Type { get; set; }

        public TransactionCase Case { get; set; }
        
        public bool Payed { get; set; }

        public String? Ip { get; set; }

        public string? RefId { get; set; }

        public string? Description { get; set; }

        public User.User User { get; set; }

        public Order.Order? Order { get; set; }


    }
}
