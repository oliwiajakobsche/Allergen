using System;
using System.Collections.Generic;

#nullable disable

namespace AllergenBackend.Models
{
    public partial class TakingCategory
    {
        public TakingCategory()
        {
            Takings = new HashSet<Taking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Taking> Takings { get; set; }
    }
}
