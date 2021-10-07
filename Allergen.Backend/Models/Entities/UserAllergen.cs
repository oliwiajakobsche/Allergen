using System;
using System.Collections.Generic;

#nullable disable

namespace AllergenBackend.Models
{
    public partial class UserAllergen
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AllergenId { get; set; }
        public DateTime Created { get; set; }

        public virtual Allergen Allergen { get; set; }
        public virtual User User { get; set; }
    }
}
