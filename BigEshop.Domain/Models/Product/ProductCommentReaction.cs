using BigEshop.Domain.Enums.Product;
using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Product
{
    public class ProductCommentReaction : BaseEntity<int>
    {
        public int ProductId { get; set; }

        public int CommentId { get; set; }

        public int UserId { get; set; }

        public ProductCommentReactionType Type { get; set; }

        public User.User User { get; set; }

        public ProductComment ProductComment { get; set; }
    }
}
