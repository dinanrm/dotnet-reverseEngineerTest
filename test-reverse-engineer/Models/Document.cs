using System;
using System.Collections.Generic;

namespace test_reverse_engineer.Models
{
    public partial class Document
    {
        public int DocId { get; set; }
        public int? ProjectId { get; set; }
        public string DocName { get; set; }
        public decimal? DocSize { get; set; }
        public string DocFormat { get; set; }
        public byte[] DocStream { get; set; }
        public string DocCategory { get; set; }
        public string DocDescription { get; set; }
        public string DocStatus { get; set; }
        public DateTime DocCreatedDate { get; set; }
        public DateTime DocModifiedDate { get; set; }

        public virtual Project Project { get; set; }
    }
}
