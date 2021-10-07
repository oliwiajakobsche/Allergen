using System;
using System.Collections.Generic;

#nullable disable

namespace AllergenBackend.Models
{
    public partial class AllergenCustom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int UserId { get; set; }

        public virtual AllergenType Type { get; set; }
        public virtual User User { get; set; }
    }
}
