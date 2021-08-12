using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Appointment
{
    public class PastAppointmentsPatientInfoDTO : AppointmentPatientFutureInfoDTO
    {
        public string Prescription { get; set; }
    }
}
