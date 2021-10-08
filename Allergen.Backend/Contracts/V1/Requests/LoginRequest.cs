using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllergenBackend.Contracts.V1.Requests
{
    public class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
