using BigEshop.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Order
{
    public class OrderViewModel
    {
        public int UserId { get; set; }

        public int? AdresId { get; set; }

        public bool IsFinally { get; set; }

        public Models.User.User? User { get; set; }

        public ICollection<Models.Order.OrderDetail>? OrderDetails { get; set; }

        public ICollection<Models.Wallet.Wallet>? Wallets { get; set; }

        public Models.Adres.Adres? Adres { get; set; }
    }
}
