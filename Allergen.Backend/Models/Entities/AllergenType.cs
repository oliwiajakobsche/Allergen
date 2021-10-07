using System;
using System.Collections.Generic;

#nullable disable

namespace AllergenBackend.Models
{
    public partial class AllergenType
    {
        public AllergenType()
        {
            AllergenCustoms = new HashSet<AllergenCustom>();
            Allergens = new HashSet<Allergen>();
        }

        public int Id { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AllergenCustom> AllergenCustoms { get; set; }
        public virtual ICollection<Allergen> Allergens { get; set; }
    }
}
