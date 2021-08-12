using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TreatLines.Models.Response;

namespace TreatLines.Models.Appointment
{
    public class AppointmentCreationModel
    {
        [Required(ErrorMessage = "You have to choose date and time for appointment.")]
        public string DateTimeAppointment { get; set; }
        public string PatientEmail { get; set; }
        public string DoctorEmail { get; set; }
        public IEnumerable<string> PatientsEmails { get; set; }
        public IEnumerable<string> DoctorsEmails { get; set; }
        public IEnumerable<FreeDateTimeModel> FreeDatesTime { get; set; }
    }
}
