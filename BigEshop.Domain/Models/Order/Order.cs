using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Order
{
    public class Order : BaseEntity<int>
    {
        public int UserId { get; set; }

        public int? AdresId { get; set; }

        public bool IsFinally { get; set; }

        public User.User? User { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }

        public ICollection<Wallet.Wallet> Wallets { get; set; }

        //[ForeignKey("AdresId")]
        public Adres.Adres Adres { get; set; }

    }
}
