using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Appointment
{
    public class AppointmentFutureInfoDTO : AppointmentDTO
    {
        public string PatientEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
