using BigEshop.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.ViewModels.Role
{
    public class FilterRoleViewModel : BasePaging<RoleViewModel>
    {
        [Display(Name = "عنوان")]
        public string Title { get; set; }
    }
}
