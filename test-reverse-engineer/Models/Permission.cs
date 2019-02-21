using System;
using System.Collections.Generic;

namespace test_reverse_engineer.Models
{
    public partial class Permission
    {
        public Permission()
        {
            RoleHasPermission = new HashSet<RoleHasPermission>();
        }

        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public DateTime PermissionCreatedDate { get; set; }
        public DateTime PermissionModifiedDate { get; set; }

        public virtual ICollection<RoleHasPermission> RoleHasPermission { get; set; }
    }
}
