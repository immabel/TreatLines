using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Doctor
{
    public class DoctorProfileInfoDTO : DoctorInfoDTO
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string WorkDays { get; set; }
    }
}
