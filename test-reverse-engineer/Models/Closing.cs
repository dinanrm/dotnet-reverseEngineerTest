using System;
using System.Collections.Generic;

namespace test_reverse_engineer.Models
{
    public partial class Closing
    {
        public Closing()
        {
            ProjectNavigation = new HashSet<Project>();
        }

        public int ClosingId { get; set; }
        public int? ProjectId { get; set; }
        public string ClosingLessonLearned { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<Project> ProjectNavigation { get; set; }
    }
}
