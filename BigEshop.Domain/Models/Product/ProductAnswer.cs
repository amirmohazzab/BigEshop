﻿using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.Product
{
    public class ProductAnswer : BaseEntity<int>
    {
        public int ProductId { get; set; }

        public int QuestionId { get; set; }

        public int UserId { get; set; }

        public string AnswerText { get; set; }

        [ForeignKey("QuestionId")]
        public ProductQuestion? ProductQuestion { get; set; }

        public User.User User { get; set; }

        public ICollection<ProductAnswerReaction>? ProductAnswerReactions { get; set; }
    }
}
