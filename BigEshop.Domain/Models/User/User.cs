using BigEshop.Domain.Enums.User;
using BigEshop.Domain.Models.Common;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.Models.Ticket;
using BigEshop.Domain.Models.Weblog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.User
{
    public class User : BaseEntity<int>
    {
        [Display(Name = "نام")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string? FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string? LastName { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(15, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string Mobile { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string Password { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string? Email { get; set; }

        [Display(Name = "کد تایید")]
        [MaxLength(12, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
        public string? ConfirmCode { get; set; }

        [Display(Name = "وضعیت کاربر")]
        public UserStatus Status { get; set; }

        [Display(Name = "تصویر کاربر")]
        public string? Avatar { get; set; }

        public bool IsDelete { get; set; } = false;

        public List<UserRole>? UserRoles { get; set; }

        public ICollection<Order.Order>? Orders { get; set; }

        public ICollection<ProductComment> ProductComments { get; set; }

        public ICollection<Wallet.Wallet> Wallets { get; set; }

        public ICollection<Contact.Contact> AnswerContacts { get; set; }

        public ICollection<Ticket.Ticket> Tickets { get; set; }

        public ICollection<Ticket.TicketMessage> TicketMessages { get; set; }

        public ICollection<ProductCommentReaction> ProductCommentReactions { get; set; }

        public ICollection<WeblogComment> WeblogComments { get; set; }

        public ICollection<Weblog.Weblog> Weblogs { get; set; }

        public ICollection<ProductQuestion> ProductQuestions { get; set; }

        public ICollection<ProductAnswer> ProductAnswers { get; set; }

        public ICollection<ProductReaction> ProductReactions { get; set; }

        public ICollection<WeblogCommentAnswer> WeblogCommentAnswers { get; set; }

        public ICollection<ProductVisit>? ProductVisits { get; set; }

        public ICollection<WeblogVisit>? WeblogVisits { get; set; }

        public ICollection<ProductAnswerReaction> ProductAnswerReactions { get; set; }
    }
}
