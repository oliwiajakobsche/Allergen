using System;
using System.Collections.Generic;

#nullable disable

namespace AllergenBackend.Models
{
    public partial class PollenCalendarArea
    {
        public PollenCalendarArea()
        {
            PollenCallendars = new HashSet<PollenCallendar>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string GoogleMapsLayer { get; set; }

        public virtual ICollection<PollenCallendar> PollenCallendars { get; set; }
    }
}
