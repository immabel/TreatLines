using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Appointment
{
    public class AppointmentCreationDTO
    {
        public DateTimeOffset DateTimeAppointment { get; set; }
        public string PatientEmail { get; set; }
        public string DoctorEmail { get; set; }
    }
}
