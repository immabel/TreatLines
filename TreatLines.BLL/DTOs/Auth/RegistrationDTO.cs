using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Auth
{
    public class RegistrationDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int HospitalId { get; set; }
    }
}
