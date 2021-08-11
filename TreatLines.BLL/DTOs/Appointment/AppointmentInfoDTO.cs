using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Appointment
{
    public class AppointmentInfoDTO : AppointmentDTO
    {
        public int? PrescriptionId { get; set; }
        public string Description { get; set; }
    }
}
