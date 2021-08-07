using System;
using System.Collections.Generic;
using System.Text;
using TreatLines.BLL.DTOs.HospitalAdmin;

namespace TreatLines.BLL.DTOs.Doctor
{
    public class DoctorInfoDTO : HospitalAdminInfoDTO
    {
        public string Position { get; set; }
        public bool OnHoliday { get; set; }
        public string Sex { get; set; }
    }
}
