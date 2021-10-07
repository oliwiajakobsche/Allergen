using System;
using System.Collections.Generic;

#nullable disable

namespace AllergenBackend.Models
{
    public partial class Allergen
    {
        public Allergen()
        {
            PollenCallendars = new HashSet<PollenCallendar>();
            UserAllergens = new HashSet<UserAllergen>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }

        public virtual AllergenType Type { get; set; }
        public virtual ICollection<PollenCallendar> PollenCallendars { get; set; }
        public virtual ICollection<UserAllergen> UserAllergens { get; set; }
    }
}
