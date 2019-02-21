using System;
using System.Collections.Generic;

namespace test_reverse_engineer.Models
{
    public partial class Plan
    {
        public Plan()
        {
            ProjectNavigation = new HashSet<Project>();
        }

        public int PlanId { get; set; }
        public int? ProjectId { get; set; }
        public string PlanLessonLearned { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<Project> ProjectNavigation { get; set; }
    }
}
