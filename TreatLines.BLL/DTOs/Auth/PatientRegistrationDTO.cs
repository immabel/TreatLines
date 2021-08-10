using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Auth
{
    public class PatientRegistrationDTO : RegistrationDTO
    {
        public string BloodType { get; set; }
        public string Sex { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
    }
}
