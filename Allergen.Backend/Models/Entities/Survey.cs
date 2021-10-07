using System;
using System.Collections.Generic;

#nullable disable

namespace AllergenBackend.Models
{
    public partial class Survey
    {
        public Survey()
        {
            SurveyDetailSymptoms = new HashSet<SurveyDetailSymptom>();
            SurveyDetailTakings = new HashSet<SurveyDetailTaking>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Feeling { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<SurveyDetailSymptom> SurveyDetailSymptoms { get; set; }
        public virtual ICollection<SurveyDetailTaking> SurveyDetailTakings { get; set; }
    }
}
