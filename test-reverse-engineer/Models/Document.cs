using System;
using System.Collections.Generic;

namespace test_reverse_engineer.Models
{
    public partial class Document
    {
        public Document()
        {
            DocCreatedDate = DateTime.Now;
            DocModifiedDate = DateTime.Now;
        }

        public int DocId { get; set; }
        public int? ProjectId { get; set; }
        public int? CategoryId { get; set; }
        public string DocName { get; set; }
        public string DocDescription { get; set; }
        public string DocStatus { get; set; }
        public byte[] DocStream { get; set; }
        public DateTime DocCreatedDate { get; set; }
        public DateTime DocModifiedDate { get; set; }

        public virtual Category Category { get; set; }
        public virtual Project Project { get; set; }
    }
}
