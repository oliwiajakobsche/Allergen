using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllergenBackend.Contracts.V1.Responses
{
    public class UserPolluteCalendarDto
    {
        public string AllergenName { get; set; }
        public byte? ImpactLevel { get; set; }
    }
}
