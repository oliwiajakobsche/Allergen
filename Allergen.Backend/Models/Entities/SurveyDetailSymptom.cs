using System;
using System.Collections.Generic;

#nullable disable

namespace AllergenBackend.Models
{
    public partial class SurveyDetailSymptom
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int SymptomId { get; set; }
        public int Value { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual Symptom Symptom { get; set; }
    }
}
