using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Appointment
{
    public class AppointmentsPatientFutureInfoDTO
    {
        public int Id { get; set; }
        public string DateTimeAppointment { get; set; }
        public string DoctorEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int Canceled { get; set; }
    }
}
