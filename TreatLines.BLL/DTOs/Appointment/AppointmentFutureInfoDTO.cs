using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Appointment
{
    public class AppointmentFutureInfoDTO
    {
        public int Id { get; set; }
        public string DateTimeAppointment { get; set; }
        public string PatientEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Canceled { get; set; }
    }
}
