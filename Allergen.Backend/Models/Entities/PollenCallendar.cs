using System;
using System.Collections.Generic;

#nullable disable

namespace AllergenBackend.Models
{
    public partial class PollenCallendar
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public int AllergenId { get; set; }
        public DateTime Date { get; set; }
        public byte ImpactLevel { get; set; }

        public virtual Allergen Allergen { get; set; }
        public virtual PollenCalendarArea Area { get; set; }
    }
}
