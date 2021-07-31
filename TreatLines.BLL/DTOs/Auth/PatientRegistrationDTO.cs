using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Auth
{
    public class PatientRegistrationDTO : RegistrationDTO
    {
        public int HospitalId { get; set; }
        public string BloodType { get; set; }
        public string Sex { get; set; }
    }
}
