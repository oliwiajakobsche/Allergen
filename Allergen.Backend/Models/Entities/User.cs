using System;
using System.Collections.Generic;

#nullable disable

namespace AllergenBackend.Models
{
    public partial class User
    {
        public User()
        {
            AllergenCustoms = new HashSet<AllergenCustom>();
            Surveys = new HashSet<Survey>();
            UserAllergens = new HashSet<UserAllergen>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public byte IsActive { get; set; }
        public byte SexId { get; set; }

        public virtual ICollection<AllergenCustom> AllergenCustoms { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<UserAllergen> UserAllergens { get; set; }
    }
}
