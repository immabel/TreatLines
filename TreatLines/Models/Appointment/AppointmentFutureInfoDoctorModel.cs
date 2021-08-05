using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.Models.Appointment
{
    public class AppointmentFutureInfoDoctorModel
    {
        public int Id { get; set; }
        public string DateTimeAppointment { get; set; }
        public string PatientEmail { get; set; }
        public string FullName { get; set; }
        public int Canceled { get; set; }
    }
}
