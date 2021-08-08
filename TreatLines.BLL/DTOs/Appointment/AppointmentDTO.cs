using System;
using System.Collections.Generic;
using System.Text;

namespace TreatLines.BLL.DTOs.Appointment
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public string DateTimeAppointment { get; set; }
        public decimal Price { get; set; }
        public decimal PriceWithDiscount { get; set; }
        public bool Canceled { get; set; }
    }
}
