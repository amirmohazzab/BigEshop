using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Enums.User
{
    public enum UserStatus
    {
        [Display(Name="غیر فعال")]
        NotActive,

        [Display(Name = "فعال")]
        Active,

        [Display(Name = "فاقد مجوز")]
        Ban
    }
}
