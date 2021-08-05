using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Appointment
{
    public class AppointmentInfoDTO
    {
        public int Id { get; set; }
        public string DateTimeAppointment { get; set; }
        public int PrescriptionId { get; set; }
        public string Prescription { get; set; }
    }
}
