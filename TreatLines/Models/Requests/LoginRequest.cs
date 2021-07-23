using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TreatLines.Models.Requests
{
    public class LoginRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,16}$", ErrorMessage = "Password is not valid")]
        public string Password { get; set; }
    }
}
