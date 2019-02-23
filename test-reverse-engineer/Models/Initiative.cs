using System;
using System.Collections.Generic;

namespace test_reverse_engineer.Models
{
    public partial class Initiative
    {
        public Initiative()
        {
            ProjectNavigation = new HashSet<Project>();
        }

        public int InitiativeId { get; set; }
        public int? ProjectId { get; set; }
        public string InitiativeTitle { get; set; }
        public DateTime? PreparedDate { get; set; }
        public string BackgroundInformation { get; set; }
        public string ObjectiveBenefit { get; set; }
        public decimal? LandCompensation { get; set; }
        public decimal? LandImprovement { get; set; }
        public decimal? Building { get; set; }
        public decimal? Infrastructure { get; set; }
        public decimal? PlantMachine { get; set; }
        public decimal? Equipment { get; set; }
        public decimal? ExpenseUnderDevelopment { get; set; }
        public decimal? WorkingCapital { get; set; }
        public decimal? Contingency { get; set; }
        public decimal? Total { get; set; }
        public string Timeline { get; set; }
        public string RequestedBy { get; set; }
        public string AcknowledgedBy { get; set; }
        public string AgreedBy { get; set; }
        public string ExecutiveSummary { get; set; }
        public string ProjectDefinition { get; set; }
        public string Vision { get; set; }
        public string Objective { get; set; }
        public string InitiativeLessonLearned { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<Project> ProjectNavigation { get; set; }
    }
}
