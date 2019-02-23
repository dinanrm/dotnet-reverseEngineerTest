using System;
using System.Collections.Generic;

namespace test_reverse_engineer.Models
{
    public partial class Role
    {
        public Role()
        {
            Assign = new HashSet<Assign>();
            RoleHasPermission = new HashSet<RoleHasPermission>();

            RoleCreatedDate = DateTime.Now;
            RoleModifiedDate = DateTime.Now;
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime RoleCreatedDate { get; set; }
        public DateTime RoleModifiedDate { get; set; }

        public virtual ICollection<Assign> Assign { get; set; }
        public virtual ICollection<RoleHasPermission> RoleHasPermission { get; set; }
    }
}
