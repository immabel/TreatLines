using System;
using System.Collections.Generic;
using System.Text;
using TreatLines.BLL.DTOs.HospitalAdmin;

namespace TreatLines.BLL.DTOs.Patient
{
    public class PatientInfoDTO : HospitalAdminInfoDTO
    {
        public string BloodType { get; set; }
        public string Sex { get; set; }
        public double Discount { get; set; }
        public string DateOfBirth { get; set; }
    }
}
