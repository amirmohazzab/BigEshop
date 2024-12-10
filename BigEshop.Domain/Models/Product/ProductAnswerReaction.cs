using BigEshop.Domain.Enums.Product;
using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Product
{
    public class ProductAnswerReaction : BaseEntity<int>
    {
        public int ProductId { get; set; }

        public int AnswerId { get; set; }

        public int UserId { get; set; }

        public ProductAnswerReactionType Type { get; set; }

        public User.User User { get; set; }

        [ForeignKey("AnswerId")]
        public ProductAnswer ProductAnswer { get; set; }
    }
}
