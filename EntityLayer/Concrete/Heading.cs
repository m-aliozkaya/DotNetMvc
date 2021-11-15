using System;
using System.Collections;
using System.Collections.Generic;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HeadingDate { get; set; }
        public bool Status { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}
