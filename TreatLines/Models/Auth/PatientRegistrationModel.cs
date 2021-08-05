using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.Models.Auth
{
    public class PatientRegistrationModel : RegistrationModel
    {
        public string BloodType { get; set; }
        public string Sex { get; set; }
    }
}
