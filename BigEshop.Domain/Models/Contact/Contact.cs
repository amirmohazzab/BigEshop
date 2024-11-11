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
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? Answer { get; set; }

        public int? AnswerUserId { get; set; }

        public string Ip { get; set; }

        public User.User? AnswerUser { get; set; }
    }
}
