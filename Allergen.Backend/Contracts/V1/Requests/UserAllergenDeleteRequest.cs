using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllergenBackend.Contracts.V1.Requests
{
    public class UserAllergenDeleteRequest
    {
        public int AllergenId { get; set; }
        public int UserId { get; set; }
    }
}
