using BigEshop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Models.User
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        [MaxLength(150)]
        public string PermissionName { get; set; }

        [MaxLength(150)]
        public string PermissionTitle { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Permission? CheckPermission { get; set; }

        public ICollection<Permission>? Permissions { get; set; }

        public ICollection<RolePermission>? RolePermissions { get; set; }

    }
}
