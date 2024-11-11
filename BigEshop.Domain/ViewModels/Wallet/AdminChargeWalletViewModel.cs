using BigEshop.Domain.Enums.Wallet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Wallet
{
	public class AdminChargeWalletViewModel
	{

        [Display(Name = "کاربر")]
        public int UserId { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }

        [Display(Name = "نوع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public TransactionType Type { get; set; }

        [Display(Name = "علت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public TransactionCase Case { get; set; }

        [Display(Name = "کد پیگیری")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string? RefId { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(850, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string? Description { get; set; }
	}
}
