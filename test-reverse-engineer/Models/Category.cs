using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_reverse_engineer.Models
{
    public class Category
    {
        public Category()
        {
            new HashSet<Assign>();
            CategoryCreatedDate = DateTime.Now;
            CategoryModifiedDate = DateTime.Now;
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public byte[] FileStream { get; set; }
        public DateTime CategoryCreatedDate { get; set; }
        public DateTime CategoryModifiedDate { get; set; }

        public virtual ICollection<Document> Document { get; set; }
    }
}
