using System;
using System.Collections.Generic;

#nullable disable

namespace AllergenBackend.Models
{
    public partial class SurveyDetailTaking
    {
        public int Id { get; set; }
        public int TakingId { get; set; }
        public int SurveyId { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual Taking Taking { get; set; }
    }
}
