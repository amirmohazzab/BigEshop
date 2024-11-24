using BigEshop.Domain.Enums.Product;
using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Product
{
    public class ProductComment : BaseEntity<int>
    {
        public int ProductId { get; set; }

        public int UserId { get; set; }

        public string Text { get; set; }

        public string Advantages { get; set; }

        public string DisAdvantages { get; set; }

        public ProductCommentStatus Status { get; set; }

        public Product Product { get; set; }

        public User.User User { get; set; }

        public ICollection<ProductCommentReaction> ProductCommentReactions { get; set; }
    }
}
