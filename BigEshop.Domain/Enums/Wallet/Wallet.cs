using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Enums.Wallet
{
    public enum TransactionType
    {
       [Display(Name = "برداشت")]
       Creditor,

       [Display(Name = "واریز")]
       Deposite
    }

    public enum TransactionCase
    {
		[Display(Name = "شارژ کیف پول")]
		ChargeWallet,

		[Display(Name = "خرید محصول")]
		BuyProduct
    }
}
