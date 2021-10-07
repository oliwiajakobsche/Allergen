using System;
using System.Collections.Generic;

#nullable disable

namespace AllergenBackend.Models
{
    public partial class Symptom
    {
        public Symptom()
        {
            SurveyDetailSymptoms = new HashSet<SurveyDetailSymptom>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Question { get; set; }
        public byte Scale { get; set; }

        public virtual ICollection<SurveyDetailSymptom> SurveyDetailSymptoms { get; set; }
    }
}
