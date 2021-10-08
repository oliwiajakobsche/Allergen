using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllergenBackend.Contracts.V1.Responses
{
    public class UserAllergenDto
    {
        public int AllergenId { get; set; }
        public int? UserAllergenId { get; set; }
        public string AllergenName { get; internal set; }
    }
}
