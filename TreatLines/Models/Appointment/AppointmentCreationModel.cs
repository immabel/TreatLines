using System;
using System.Collections.Generic;
using System.Text;
using TreatLines.Models.Response;

namespace TreatLines.Models.Appointment
{
    public class AppointmentCreationModel
    {
        public string DateTimeAppointment { get; set; }
        public string PatientEmail { get; set; }
        public string DoctorEmail { get; set; }
        public IEnumerable<string> PatientsEmails { get; set; }
        public IEnumerable<string> DoctorsEmails { get; set; }
        public IEnumerable<FreeDateTimeModel> FreeDatesTime { get; set; }
    }
}
