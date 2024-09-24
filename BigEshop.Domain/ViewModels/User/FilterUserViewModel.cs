using BigEshop.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.User
{
	public class FilterUserViewModel : BasePaging<UserViewModel>
	{
        public string? FirstName { get; set; }
    }
}
