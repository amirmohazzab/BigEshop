﻿using BigEshop.Domain.Enums.Ticket;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Ticket
{
    public class AdminCreateTicketViewModel
    {

        [Display(Name = "کاربر")]
        public int UserId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string Title { get; set; }

        [Display(Name = "اولویت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public TicketPriority Priority { get; set; }

        [Display(Name = "بخش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public TicketSection Section { get; set; }

        [Display(Name = "پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(800, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string Message { get; set; }
    }
}
