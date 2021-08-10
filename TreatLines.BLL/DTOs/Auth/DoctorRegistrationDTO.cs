using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Auth
{
    public class DoctorRegistrationDTO : RegistrationDTO
    {
        public string Position { get; set; }
        public int ScheduleId { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public string Sex { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public decimal Price { get; set; }
    }
}
