using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.User
{
	public class Role : BaseEntity<int>
	{
		[Display(Name = "نفش کاربر")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(400, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است")]
		public string RoleTitle { get; set; }

		public List<UserRole>? UserRoles { get; set; }

        public ICollection<RolePermission>? RolePermissions { get; set; }
    }
}
