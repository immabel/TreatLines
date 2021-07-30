using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.PatientCreate
{
    public sealed class RequestToCreatePatientDTO
    {
        public string HospitalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string BloodType { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
    }
}
