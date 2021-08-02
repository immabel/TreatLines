using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Patient
{
    public class PatientProfileInfoDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string BloodType { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string HospitalName { get; set; }
        public string Prescription { get; set; }
    }
}
