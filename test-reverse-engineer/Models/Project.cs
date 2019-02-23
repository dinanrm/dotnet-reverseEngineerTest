using System;
using System.Collections.Generic;

namespace test_reverse_engineer.Models
{
    public partial class Project
    {
        public Project()
        {
            Assign = new HashSet<Assign>();
            Closing = new HashSet<Closing>();
            Document = new HashSet<Document>();
            Execute = new HashSet<Execute>();
            Initiative = new HashSet<Initiative>();
            Plan = new HashSet<Plan>();

            ProjectCreatedDate = DateTime.Now;
            ProjectModifiedDate = DateTime.Now;
        }

        public int ProjectId { get; set; }
        public int? InitiativeId { get; set; }
        public int? ExecuteId { get; set; }
        public int? ClosingId { get; set; }
        public int? PlanId { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectCategory { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectStatus { get; set; }
        public DateTime ProjectCreatedDate { get; set; }
        public DateTime ProjectModifiedDate { get; set; }

        public virtual Closing ClosingNavigation { get; set; }
        public virtual Execute ExecuteNavigation { get; set; }
        public virtual Initiative InitiativeNavigation { get; set; }
        public virtual Plan PlanNavigation { get; set; }
        public virtual ICollection<Assign> Assign { get; set; }
        public virtual ICollection<Closing> Closing { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<Execute> Execute { get; set; }
        public virtual ICollection<Initiative> Initiative { get; set; }
        public virtual ICollection<Plan> Plan { get; set; }
    }
}
