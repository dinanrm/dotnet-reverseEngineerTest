using System;
using System.Collections.Generic;

namespace test_reverse_engineer.Models
{
    public partial class Assign
    {
        public int AssignId { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public int? ProjectId { get; set; }
        public DateTime AssignCreatedDate { get; set; }
        public DateTime AssignModifiedDate { get; set; }

        public virtual Project Project { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
