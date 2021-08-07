using System;
using System.Collections.Generic;
using System.Text;
using TreatLines.BLL.DTOs.Schedule;

namespace TreatLines.BLL.DTOs.Doctor
{
    public class DoctorProfileInfoDTO : DoctorInfoDTO
    {
        public decimal Price { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public string BirthDate { get; set; }
        public int ScheduleId { get; set; }
    }
}
