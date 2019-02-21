using System;
using System.Collections.Generic;

namespace test_reverse_engineer.Models
{
    public partial class Execute
    {
        public Execute()
        {
            ProjectNavigation = new HashSet<Project>();
        }

        public int ExecuteId { get; set; }
        public int? ProjectId { get; set; }
        public string ExecuteLessonLearned { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<Project> ProjectNavigation { get; set; }
    }
}
