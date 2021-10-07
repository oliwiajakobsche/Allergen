using System;
using System.Collections.Generic;

#nullable disable

namespace AllergenBackend.Models
{
    public partial class Taking
    {
        public Taking()
        {
            SurveyDetailTakings = new HashSet<SurveyDetailTaking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public virtual TakingCategory Category { get; set; }
        public virtual ICollection<SurveyDetailTaking> SurveyDetailTakings { get; set; }
    }
}
