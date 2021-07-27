using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreatLines.Models.Response
{
    public class LoginResponse
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
