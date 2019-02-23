using System;
using System.Collections.Generic;

namespace test_reverse_engineer.Models
{
    public partial class User
    {
        public User()
        {
            Assign = new HashSet<Assign>();

            UserCreatedDate = DateTime.Now;
            UserModifiedDate = DateTime.Now;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserStatus { get; set; }
        public DateTime UserCreatedDate { get; set; }
        public DateTime UserModifiedDate { get; set; }

        public virtual ICollection<Assign> Assign { get; set; }
    }
}
