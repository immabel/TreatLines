using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.Models.Appointment
{
    public class AppointmentCreationModel
    {
        public string DateTimeAppointment { get; set; }
        public string PatientEmail { get; set; }
        public string DoctorEmail { get; set; }
    }
}
