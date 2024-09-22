using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.User
{
	public class UserRole : BaseEntity<int>
	{
		public int RoleId { get; set; }

        public int UserId { get; set; }

		[ForeignKey("RoleId")]
		public Role? Role { get; set; }

		[ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
